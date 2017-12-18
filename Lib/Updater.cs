
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2017.Templates;

namespace AdventOfCode2017 {

    class Updater {

        Generator generator = new TemplateEngine().Load(Path.Combine("lib", "templates"));

        public async Task Update(int day) {
            if (!System.Environment.GetEnvironmentVariables().Contains("SESSION")) {
                throw new Exception("Specify SESSION environment variable");
            }

            var dir = $"Day{day.ToString("00")}";
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }
            var title = "???";

            var cookieContainer = new CookieContainer();
            using (var client = new HttpClient(
                new HttpClientHandler {
                    CookieContainer = cookieContainer,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                })) {
                var baseAddress = new Uri("https://adventofcode.com/");
                client.BaseAddress = baseAddress;
                cookieContainer.Add(baseAddress, new Cookie("session", System.Environment.GetEnvironmentVariable("SESSION")));

                var calendarTokens = await CalendarTokens(client);
                UpdateProjectReadme(calendarTokens);
                UpdateSplashScreen(calendarTokens);
                
                title = await UpdateReadmeForDay(client, day);
                await UpdateInput(client, day);
            }

            UpdateSolutionTemplate(day, title);
        }
        
        async Task<string> Download(HttpClient client, string path) {
            Console.WriteLine($"Downloading {client.BaseAddress + path}");
            var response = await client.GetAsync(path);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        async Task<IEnumerable<CalendarToken>> CalendarTokens(HttpClient client) {
            var html = await Download(client, "2017");
            return new CalendarParser().Parse(html);
        }

        async Task<string> UpdateReadmeForDay(HttpClient client, int day) {
            var response = await Download(client, $"2017/day/{day}");
        
            var md = ToMarkDown(response, client.BaseAddress + $"/2017/day/{day}");
            var fileTo = Path.Combine(Dir(day), "README.md");
            WriteFile(fileTo, md.content);
            return md.title;
        }

        void UpdateSolutionTemplate(int day, string title) {
            var solution = Path.Combine(Dir(day),"Solution.cs");
            if (!File.Exists(solution)) {
                WriteFile(solution, generator.GenerateSolutionTemplate(new SolutionTemplateModel { Day = day, Title = title }));
            }
        }

        void UpdateProjectReadme(IEnumerable<CalendarToken> calendarTokens) {
            var file = Path.Combine("README.md");

            WriteFile(file, generator.GenerateProjectReadme(new ProjectReadmeModel { 
                Calendar = string.Join("", calendarTokens.Select(x => x.Text))
            }));
        }

        void UpdateSplashScreen(IEnumerable<CalendarToken> calendarTokens) {
            var file = Path.Combine(Path.Combine("lib", "SplashScreen.cs"));

            WriteFile(file, generator.GenerateSplashScreen(new SplashScreenModel { 
                Calendar = calendarTokens
            }));
        }

        async Task UpdateInput(HttpClient client, int day) {
            var response = await Download(client, $"2017/day/{day}/input");
            var inputFile = Path.Combine(Dir(day), "input.in");
            WriteFile(inputFile, response);
        }

        void WriteFile(string file, string content) {
            Console.WriteLine($"Writing {file}");
            File.WriteAllText(file, content);
        }

        string Dir(int day) => $"Day{day.ToString("00")}";

        (string title, string content) ToMarkDown(string input, string url) {
            var document = new HtmlDocument();
            document.LoadHtml(input);
            var st = $"original source: [{url}]({url})\n";
            foreach (var article in document.DocumentNode.SelectNodes("//article")) {
                st += UnparseList("", article) + "\n";
            }
            var title = HtmlEntity.DeEntitize(document.DocumentNode.SelectNodes("//h2").First().InnerText);

            var match = Regex.Match(title, ".*: (.*) ---");
            if (match.Success) {
                title = match.Groups[1].Value;
            }
            return (title, st);
        }

        string UnparseList(string sep, HtmlNode node) {
            return string.Join(sep, node.ChildNodes.SelectMany(Unparse));
        }

        IEnumerable<string> Unparse(HtmlNode node) {
            switch (node.Name) {
                case "h2":
                    yield return "## " + UnparseList("", node) + "\n";
                    break;
                case "p":
                    yield return UnparseList("", node) + "\n";
                    break;
                case "em":
                    yield return "*" + UnparseList("", node) + "*";
                    break;
                case "code":
                    if (node.ParentNode.Name == "pre") {
                        yield return UnparseList("", node);
                    } else {
                        yield return "`" + UnparseList("", node) + "`";
                    }
                    break;
                case "span":
                    yield return UnparseList("", node);
                    break;
                case "s":
                    yield return "~~" + UnparseList("", node) + "~~";
                    break;
                case "ul":
                    foreach (var unparsed in node.ChildNodes.SelectMany(Unparse)) {
                        yield return unparsed;
                    }
                    break;
                case "li":
                    yield return " - " + UnparseList("", node);
                    break;
                case "pre":
                    yield return "```\n";
                    var freshLine = true;
                    foreach (var item in node.ChildNodes) {
                        foreach (var unparsed in Unparse(item)) {
                            freshLine = unparsed[unparsed.Length - 1] == '\n';
                            yield return unparsed;
                        }
                    }
                    if (freshLine) {
                        yield return "```\n";
                    } else {
                        yield return "\n```\n";
                    }
                    break;
                case "a":
                    yield return "[" + UnparseList("", node) + "](" + node.Attributes["href"].Value + ")";
                    break;
                case "#text":
                    yield return HtmlEntity.DeEntitize(node.InnerText);
                    break;
                default:
                    throw new NotImplementedException(node.InnerHtml);
            }
        }
    }
}
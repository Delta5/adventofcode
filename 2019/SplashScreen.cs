
using System;

namespace AdventOfCode.Y2019 {

    class SplashScreenImpl : AdventOfCode.SplashScreen {

        public void Show() {

            var color = Console.ForegroundColor;
            Write(0xffff66, false, "\n  __   ____  _  _  ____  __ _  ____     __  ____     ___  __  ____  ____         \n / _\\ (    \\/ )( ");
            Write(0xffff66, false, "\\(  __)(  ( \\(_  _)   /  \\(  __)   / __)/  \\(    \\(  __)        \n/    \\ ) D (\\ \\/ / ) _) /    /  )( ");
            Write(0xffff66, false, "   (  O )) _)   ( (__(  O )) D ( ) _)         \n\\_/\\_/(____/ \\__/ (____)\\_)__) (__)    \\__/(__)     \\");
            Write(0xffff66, false, "___)\\__/(____/(____)  2019\n\n                                   ");
            Write(0x333333, false, ".  .  .         .      .   ");
            Write(0x666666, false, "25\n           ");
            Write(0x333333, false, ".......                           .                ");
            Write(0x666666, false, "24\n           ");
            Write(0x333333, false, "       '''''...      .                             ");
            Write(0x666666, false, "23\n                ");
            Write(0x333333, false, ".         ''..                                ");
            Write(0x666666, false, "22\n           ");
            Write(0x333333, false, "......    .        ''.                             ");
            Write(0x666666, false, "21\n           ");
            Write(0x333333, false, "      ''''...         '..       .                  ");
            Write(0x666666, false, "20\n                ");
            Write(0x333333, false, ".       ''..       '.                      .  ");
            Write(0x666666, false, "19\n           ");
            Write(0x333333, false, ".....         .. ''.      '.          .        .   ");
            Write(0x666666, false, "18\n           ");
            Write(0x333333, false, "     ''''...        '.      '.         .           ");
            Write(0x666666, false, "17\n           ");
            Write(0x333333, false, "            '..       '.      '.             .     ");
            Write(0x666666, false, "16\n           ");
            Write(0x333333, false, "               '.       '.     '..   .             ");
            Write(0x666666, false, "15\n           ");
            Write(0x333333, false, "'''''...      .  '.      '.     '.                 ");
            Write(0x666666, false, "14\n           ");
            Write(0x333333, false, "        ''..       '.   . '.     '.      .         ");
            Write(0x666666, false, "13\n           ''''...     '.      '.  ");
            Write(0x333333, false, ".");
            Write(0x666666, false, "  '");
            Write(0xd2beab, true, "O    ");
            Write(0x333333, false, ".");
            Write(0x666666, false, "'.               ");
            Write(0xcccccc, false, "12 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "       ''.  ");
            Write(0x333333, false, ".");
            Write(0x666666, false, " '.      :   ");
            Write(0x333333, false, ".");
            Write(0x666666, false, " '.     :               ");
            Write(0xcccccc, false, "11 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "'''''..   '.   '.");
            Write(0x333333, false, ".     ");
            Write(0xbabdb6, true, ".    ");
            Write(0x333333, false, ".");
            Write(0x666666, false, ":");
            Write(0x333333, false, ".");
            Write(0x666666, false, "    '.      ");
            Write(0x333333, false, ".  .    ");
            Write(0xcccccc, false, "10 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "       '.  '.   '.     '.     :     :              ");
            Write(0xcccccc, false, " 9 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "         :  '.   ");
            Write(0xf7a859, true, ".   ");
            Write(0x333333, false, ".");
            Write(0x666666, false, "  :    ");
            Write(0x333333, false, ".");
            Write(0x666666, false, ":     :              ");
            Write(0xcccccc, false, " 8 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "'''.      :  :   :      :     :     :              ");
            Write(0xcccccc, false, " 7 ");
            Write(0xffff66, false, "**\n              ");
            Write(0xbebcbe, true, ".");
            Write(0x666666, false, "      :  :   :      :     :     :              ");
            Write(0xcccccc, false, " 6 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "...' ");
            Write(0x333333, false, ".");
            Write(0x666666, false, "    :");
            Write(0x333333, false, ".");
            Write(0x666666, false, " :   :      :     :     :          ");
            Write(0x333333, false, ".   ");
            Write(0xcccccc, false, " 5 ");
            Write(0xffff66, false, "**\n                    ");
            Write(0xe3e2e0, true, ".");
            Write(0x666666, false, "  .'   :      :    ");
            Write(0x333333, false, ".");
            Write(0x666666, false, ":     :  ");
            Write(0x333333, false, ".           ");
            Write(0xcccccc, false, " 4 ");
            Write(0xffff66, false, "**\n             ");
            Write(0x333333, false, ". .");
            Write(0x666666, false, "  .'  .'   .'     .'     :     :              ");
            Write(0xcccccc, false, " 3 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, ".....''   ");
            Write(0x91a5bd, true, ".");
            Write(0x666666, false, "'   .'      :     :     .'        ");
            Write(0x333333, false, ".  .  ");
            Write(0xcccccc, false, " 2 ");
            Write(0xffff66, false, "**\n           ");
            Write(0x666666, false, "       ..'    .'      :     .'   ");
            Write(0x333333, false, ".");
            Write(0x666666, false, " :               ");
            Write(0xcccccc, false, " 1 ");
            Write(0xffff66, false, "**\n           \n");
            
            Console.ForegroundColor = color;
            Console.WriteLine();
        }

       private static void Write(int rgb, bool bold, string text){
           Console.Write($"\u001b[38;2;{(rgb>>16)&255};{(rgb>>8)&255};{rgb&255}{(bold ? ";1" : "")}m{text}");
       }
    }
}
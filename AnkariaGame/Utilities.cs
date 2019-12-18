using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    class Utilities
    {
        public static void ClearCurrentConsoleLine()//Clears the entire line where the cursor is located on the Console
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public static void Message(string s = "", ConsoleColor c = ConsoleColor.White) //Allows you to put a custom message at the bottom of the board
        {
            Console.SetCursorPosition(0, 36);
            ClearCurrentConsoleLine();
            Console.ForegroundColor = c;
            Console.Write(s);
        }
        public static double Distance(int loc1Row, int loc1Col, int loc2Col, int loc2Row) //Uses the Distance formula of two points to return the distance value
        {
            double distance = Math.Sqrt(Math.Pow(loc2Row - loc1Row, 2)+Math.Pow(loc2Col - loc1Col, 2));
            return distance;
        }
    }
}
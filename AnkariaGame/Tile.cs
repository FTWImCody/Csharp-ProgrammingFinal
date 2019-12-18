/*
 * Programmer: Cody McNealy
 * Program: Tile Class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    class Tile
    {
        public string _ID { get; } = Guid.NewGuid().ToString("N");
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public IActor Occupied { get; set; }
        public bool StairsHere { get; set; }
        public bool CoinsHere { get; set; }

        //CONSTRUCTOR
        public Tile(string s = "#", ConsoleColor c = ConsoleColor.Blue, bool sh = false, bool ch = false, IActor oc = null)
        {
            Symbol = s;
            Color = c;
            Occupied = oc;
            StairsHere = sh; //keeps track of stairs location by tile _ID
            CoinsHere = ch; //keeps track of Coins location by tile _ID
        }
    }
}
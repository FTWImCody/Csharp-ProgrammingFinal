using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    class Shopkeeper : GameCharacter, IActor
    {
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        public Shopkeeper(string s = "T", ConsoleColor cc = ConsoleColor.DarkRed)
        {
            Name = "Traveling Merchant";
            Symbol = s;
            Color = cc;
        }

        public void Move(Board b, IActor a = null)
        {
            //Travelling Merchant doesn't move on board..
        }
        public void Interact(Board b, IActor a)
        {
            //Player Interacts with Merchant..
        }
        public void Death(Board b)
        {
            //Can not die..
        }
    }
}

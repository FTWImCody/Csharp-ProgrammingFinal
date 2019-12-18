using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    interface IActor //Ensures all the movable/interactable monsters on the board can easily be for looped through without errors
    {
        string Name { get; set; }
        int Health { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
        int Row { get; set; }
        int Col { get; set; }
        string Symbol { get; }
        ConsoleColor Color { get; }

        void Move(Board b, IActor a);
        void Interact(Board b, IActor a);
        void Death(Board b);
    }
}

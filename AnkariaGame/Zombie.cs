using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    class Zombie : Monster
    {
        public Zombie(ConsoleColor cc = ConsoleColor.DarkGreen, string s = "Z")
        {
            Symbol = s;
            Color = cc;
        }
        public override void Move(Board b, IActor a) //If player is close by, the Zombie will follow the player's row&col..otherwise, it will aimlessly roam the board
        {
            double Distance = Utilities.Distance(Row, Col, b.PCol, b.PRow);
            int oldRow = Row;
            int oldCol = Col;
            int newRow = 0;
            int newCol = 0;
            if (Distance <= 3)
            {
                int coinflip = StaticRandom.Instance.Next(1, 3);
                switch (coinflip)
                {
                    case 1:
                        if (oldRow < b.PRow)
                        {
                            newRow = oldRow + 1;
                            newCol = oldCol;
                        }
                        else if (oldRow > b.PRow)
                        {
                            newRow = oldRow - 1;
                            newCol = oldCol;
                        }
                        else if (oldCol < b.PCol)
                        {
                            newCol = oldCol + 1;
                            newRow = oldRow;
                        }
                        else if (oldCol > b.PCol)
                        {
                            newCol = oldCol - 1;
                            newRow = oldRow;
                        }
                        break;
                    case 2:
                        if (oldCol < b.PCol)
                        {
                            newCol = oldCol + 1;
                            newRow = oldRow;
                        }
                        else if (oldCol > b.PCol)
                        {
                            newCol = oldCol - 1;
                            newRow = oldRow;
                        }
                        else if (oldRow < b.PRow)
                        {
                            newRow = oldRow + 1;
                            newCol = oldCol;
                        }
                        else if (oldRow > b.PRow)
                        {
                            newRow = oldRow - 1;
                            newCol = oldCol;
                        }
                        break;
                }
                if (b.GameBoard[newCol, newRow].Occupied != null && b.GameBoard[newCol, newRow].Occupied is Player)
                {
                    Interact(b, b.GameBoard[newCol, newRow].Occupied);
                }
                if (b.GameBoard[newCol, newRow].Symbol != "#" && b.GameBoard[newCol, newRow].StairsHere == false && b.GameBoard[newCol, newRow].Occupied == null)
                {
                    b.GameBoard[oldCol, oldRow].Occupied = null;
                    //Display tile on old position
                    b.DisplayTile(oldCol, oldRow);
                    b.GameBoard[newCol, newRow].Occupied = this;
                    //Display tile on new position
                    b.DisplayTile(newCol, newRow);
                    //Update row and col on the monster
                    Col = newCol;
                    Row = newRow;
                }
            }
            else
            {
                base.Move(b, a);
            }
        }
        public override void Interact(Board b, IActor a)//If the Zombie reaches the player it will damage the player 1 Health.
        {
            if (a is Player)
            {
                a.Health -= 1;
            }
        }
    }
}
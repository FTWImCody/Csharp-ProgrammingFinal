using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    class Necromancer : Monster
    {
        public int Summon;
        public int Timer;
        public Necromancer(ConsoleColor cc = ConsoleColor.Magenta, string s = "N")
        {
            Symbol = s;
            Color = cc;
            Summon = 0;
            Timer = 0;
        }
        public override void Move(Board b, IActor a)//If player is in a radius it will summon a Zombie randomly on the board, otherwise it will roam aimlessly
        {
            if (Summon == 0)
            {
                base.Move(b, a);
            }
            if (Timer == 0)
            {
                Interact(b, a);
            }
            else
            {
                Timer--;
            }
        }
        public override void Interact(Board b, IActor a)//Summons a Zombie on the board to kill the player
        {
            double Distance = Utilities.Distance(this.Row, this.Col, b.PCol, b.PRow);
            if (Summon < 3 && Distance <= 4)
            {
                GenMon(b, 2);
                PlaceSummon(b);
                Utilities.Message("BIG OOF, " + Name + " summoned " + b.MonsterList[b.MonsterList.Count - 1].Name + "!");
                Console.ReadKey(true);
                Summon++;
                Timer = 5;
            }
        }
        public void PlaceSummon(Board b)
        {
            while (true)
            {
                int random = StaticRandom.Instance.Next(0, 8);
                int tempRow = 0;
                int tempCol = 0;
                int nRow = Row;
                int nCol = Col;
                switch (random)
                {
                    case 0:
                        tempCol = nCol + 1;
                        tempRow = nRow + 1;
                        break;
                    case 1:
                        tempCol = nCol + 1;
                        tempRow = nRow - 1;
                        break;
                    case 2:
                        tempCol = nCol - 1;
                        tempRow = nRow + 1;
                        break;
                    case 3:
                        tempCol = nCol - 1;
                        tempRow = nRow - 1;
                        break;
                    case 4:
                        tempCol = nCol;
                        tempRow = nRow + 1;
                        break;
                    case 5:
                        tempCol = nCol;
                        tempRow = nRow - 1;
                        break;
                    case 6:
                        tempCol = nCol + 1;
                        tempRow = nRow;
                        break;
                    case 7:
                        tempCol = nCol - 1;
                        tempRow = nRow;
                        break;
                }
                if (b.GameBoard[tempCol, tempRow].Symbol != "#" && b.GameBoard[tempCol, tempRow].StairsHere == false && b.GameBoard[tempCol, tempRow].Occupied == null)
                {
                    b.MonsterList[b.MonsterList.Count - 1].Col = tempCol;
                    b.MonsterList[b.MonsterList.Count - 1].Row = tempRow;
                    break;
                }
            }
        }//Places Zombie around the Necromancer that summoned it..
    }
}
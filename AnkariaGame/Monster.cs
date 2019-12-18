using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    class Monster : GameCharacter, IActor
    {
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        //CONSTRUCTOR
        public Monster(int mod = 3, int r = 0, int c = 0, ConsoleColor cc = ConsoleColor.Red, string s = "M")
        {
            Name = NameGen();
            Attack = StatGen(3, mod);
            Defense = StatGen(2, mod);
            Health = StatGen(4, mod);
            Row = r;
            Col = c;
            Symbol = s;
            Color = cc;
        }

        virtual public void Move(Board b, IActor a)//Randomly moves the monster around the board
        {
            int newY = 0;
            int newX = 0;
            int mOldY = Col;
            int mOldX = Row;
            List<ConsoleKey> VALID = new List<ConsoleKey> { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };
            ConsoleKey input = VALID[StaticRandom.Instance.Next(0, 4)];

            switch (input) {
                case ConsoleKey.W:
                    newY = mOldY - 1;
                    newX = mOldX;
                    break;
                case ConsoleKey.S:
                    newY = mOldY + 1;
                    newX = mOldX;
                    break;
                case ConsoleKey.A:
                    newY = mOldY;
                    newX = mOldX - 1;
                    break;
                case ConsoleKey.D:
                    newY = mOldY;
                    newX = mOldX + 1;
                    break;
            }

            if (b.GameBoard[newY, newX].Occupied != null && b.GameBoard[newY, newX].Occupied is Player)
            {
                Interact(b, b.GameBoard[newY, newX].Occupied);
            }
            if (b.GameBoard[newY, newX].Symbol != "#" && b.GameBoard[newY, newX].StairsHere == false && b.GameBoard[newY, newX].Occupied == null)
            {
                b.GameBoard[mOldY, mOldX].Occupied = null;
                //Display tile on old position
                b.DisplayTile(mOldY, mOldX);
                b.GameBoard[newY, newX].Occupied = this;
                //Display tile on new position
                b.DisplayTile(newY, newX);
                //Update row and col on the monster
                Col = newY;
                Row = newX;
            }
        }
        virtual public void Interact(Board b, IActor a)//If monster interacts with Player/Monster on Board
        {
            Utilities.Message("OOF, " + Name + " ran into " + a.Name + "!");
            Console.ReadKey(true);
        }
        public void Death(Board b)//If the Monsters health reaches 0..
        {
            b.GameBoard[Col, Row].Occupied = null;
            Utilities.Message(this.Name + " has dropped some coins!");
            b.GameBoard[Col, Row].CoinsHere = true;
            Console.ReadKey(true);
        }
        public static List<Monster> GenMon(Board b, int selection)//Generates a list of Necromancers or adds Zombies to the already existing list depending on selection
        {
            if (selection == 1)
            {
                int numOfMonsters = 5;
                for (int i = 0; i < numOfMonsters; i++)
                {
                    b.MonsterList.Add(new Necromancer());
                }
            }
            else if (selection == 2)
            {
                b.MonsterList.Add(new Zombie());
            }
            return b.MonsterList;
        }
    }
}
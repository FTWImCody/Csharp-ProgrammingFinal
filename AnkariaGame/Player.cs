using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    class Player : GameCharacter, IActor
    {
        public string History { get; set; }
        public int Floor { get; set; }
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public int MaxHealth { get; set; }
        public int Currency { get; set; }
        public int SmallPot { get; set; }
        public int MedPot { get; set; }
        public int LrgPot { get; set; }
        public int ScrollOfAnn { get; set; }

        //CONSTRUCTOR
        public Player(int mod = 5, int r = 0, int c = 0, ConsoleColor cc = ConsoleColor.White, string s = "@", int coin = 100)
        {
            Name = NameGen();
            History = HistoryGen();
            Attack = StatGen(3, mod);
            Defense = StatGen(3, mod);
            Health = StatGen(6, mod);
            MaxHealth = Health;
            Floor = 1;
            Row = r;
            Col = c;
            Symbol = s;
            Color = cc;
            Currency = coin;
        }
        public static Player PlayerCreation()//gives the user the ability to create a character, changing it's name and randomising stats
        {
            while (true)
            {
                Console.Clear();
                Player p = new Player();
                //Console.WriteLine("Character Creation:");
                Console.WriteLine("   ___ _                          _                ___               _   _             ");
                Console.WriteLine("  / __\\ |__   __ _ _ __ __ _  ___| |_ ___ _ __    / __\\ __ ___  __ _| |_(_) ___  _ __  ");
                Console.WriteLine(" / /  | '_ \\ / _` | '__/ _` |/ __| __/ _ \\ '__|  / / | '__/ _ \\/ _` | __| |/ _ \\| '_ \\ ");
                Console.WriteLine("/ /___| | | | (_| | | | (_| | (__| ||  __/ |    / /__| | |  __/ (_| | |_| | (_) | | | |");
                Console.WriteLine("\\____/|_| |_|\\__,_|_|  \\__,_|\\___|\\__\\___|_|    \\____/_|  \\___|\\__,_|\\__|_|\\___/|_| |_|\n");
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine(p.History);
                Console.WriteLine("Attack: " + p.Attack);
                Console.WriteLine("Defense: " + p.Defense);
                Console.WriteLine("Health: " + p.Health + "\n");
                Console.WriteLine("Do you like this character?(Y/N)");
                ConsoleKeyInfo k = Console.ReadKey(true);
                char userInput = char.ToUpper(k.KeyChar);
                if(k.Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    return p;
                }
                else if(k.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    continue;
                }
            }
        }
        public void Move(Board b, IActor a = null)//Gives the user control of the character on the board
        {
            int newY = 0;
            int newX = 0;
            int pOldY = Col;
            int pOldX = Row;
            Utilities.Message("Command (F1 for help): ");
            List<ConsoleKey> UP = new List<ConsoleKey> { ConsoleKey.NumPad8, ConsoleKey.UpArrow, ConsoleKey.W };
            List<ConsoleKey> LEFT = new List<ConsoleKey> { ConsoleKey.NumPad4, ConsoleKey.LeftArrow, ConsoleKey.A };
            List<ConsoleKey> DOWN = new List<ConsoleKey> { ConsoleKey.NumPad2, ConsoleKey.DownArrow, ConsoleKey.S };
            List<ConsoleKey> RIGHT = new List<ConsoleKey> { ConsoleKey.NumPad6, ConsoleKey.RightArrow, ConsoleKey.D };
            List<ConsoleKey> OTHER = new List<ConsoleKey> { ConsoleKey.Escape, ConsoleKey.F1, ConsoleKey.C, ConsoleKey.B };
            
            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey(true);
                char userInput = char.ToUpper(k.KeyChar);
                if (OTHER.Contains(k.Key))
                {
                    if (k.Key == ConsoleKey.F1)
                    {
                        Screen.HelpScreen();
                        b.ShowBoard();
                        PlayerHUD();
                        Utilities.Message("Command (F1 for help): ");
                    }
                    else if (k.Key == ConsoleKey.Escape)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Are you sure you would like to quit?(Y/N)");
                            ConsoleKeyInfo j = Console.ReadKey(true);
                            char userInput2 = char.ToUpper(k.KeyChar);
                            if (j.Key == ConsoleKey.Y)
                            {
                                Environment.Exit(0);
                            }
                            else if (j.Key == ConsoleKey.N)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                        b.ShowBoard();
                        PlayerHUD();
                        Utilities.Message("Command (F1 for help): ");
                    }
                    else if (k.Key == ConsoleKey.C)
                    {
                        Screen.CSheet(this);
                        b.ShowBoard();
                        PlayerHUD();
                        Utilities.Message("Command (F1 for help): ");
                    }
                    else if (k.Key == ConsoleKey.B)
                    {
                        Screen.Backpack(this, b);
                        b.ShowBoard();
                        PlayerHUD();
                        Utilities.Message("Command (F1 for help): ");
                    }
                }
                else if (UP.Contains(k.Key))
                {
                    newY = pOldY - 1;
                    newX = pOldX;
                }
                else if (DOWN.Contains(k.Key))
                {
                    newY = pOldY + 1;
                    newX = pOldX;
                }
                else if (LEFT.Contains(k.Key))
                {
                    newY = pOldY;
                    newX = pOldX - 1;
                }
                else if (RIGHT.Contains(k.Key))
                {
                    newY = pOldY;
                    newX = pOldX + 1;
                }
                else if (k.Key == ConsoleKey.NumPad1)
                {
                    newY = pOldY + 1;
                    newX = pOldX - 1;
                }
                else if (k.Key == ConsoleKey.NumPad3)
                {
                    newY = pOldY + 1;
                    newX = pOldX + 1;
                }
                /*else if (k.Key == ConsoleKey.NumPad5)
                {
                    if (Health == MaxHealth)
                    {
                        Utilities.Message("You are already at Max Health of " + MaxHealth + " Health!");
                        Console.ReadKey(true);
                        continue;
                    }
                    else
                    {
                        int Healing = StaticRandom.Instance.Next(3, 6);
                        Health += Healing;
                        if (Health > MaxHealth)
                        {
                            Health = MaxHealth;
                        }
                        Utilities.Message("You heal for " + Healing + " Health!");
                        Console.ReadKey(true);
                        break;
                    }
                }*/
                else if (k.Key == ConsoleKey.NumPad7)
                {
                    newY = pOldY - 1;
                    newX = pOldX - 1;
                }
                else if (k.Key == ConsoleKey.NumPad9)
                {
                    newY = pOldY - 1;
                    newX = pOldX + 1;
                }
                if(b.GameBoard[newY, newX].Occupied != null)
                {
                    Interact(b, b.GameBoard[newY, newX].Occupied);
                    break;
                }
                else if (b.GameBoard[newY, newX].Symbol != "#")
                {
                    //Set the old positions playerHere = false
                    b.GameBoard[pOldY, pOldX].Occupied = null;
                    //Display tile on old position
                    b.DisplayTile(pOldY, pOldX);
                    //Set new position's PlayerHere = true;
                    b.GameBoard[newY, newX].Occupied = this;
                    b.PCol = newY;
                    b.PRow = newX;
                    //Display tile on new position
                    b.DisplayTile(newY, newX);
                    //Update row and col on the player
                    Col = newY;
                    Row = newX;
                    break;
                }
            }
        }
        public void Interact(Board b, IActor a)//If player tries to move onto a monster occupied spot it will attack the Monster and deal damage according to the algorithm or if it interacts with Traveling merchant, it will open the shop..
        {
            if (a is Monster)
            {
                int Damage = (Attack - a.Defense);
                if (Damage <= 0)
                {
                    Damage = 5;
                }
                a.Health -= Damage;
                Utilities.Message("You hit " + a.Name + " for " + Damage + " damage!");
                Console.ReadKey(true);
            }
            else if (a is Shopkeeper)
            {
                //Check if Zombies or Monsters are around and if they are then don't message player to kill all enemies around before trading
                bool flag = false;

                foreach (Monster m in b.MonsterList)
                {
                    double Distance = Utilities.Distance(b.PCol, b.PRow, m.Col, m.Row);
                    if(Distance >= 5)
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag != false)
                {
                    Utilities.Message("Please kill all the monsters around before trading me!");
                    Console.ReadKey(true);
                }
                else
                {
                    Utilities.Message("Welcome to my Shop, traveler!");
                    Console.Clear();
                    Screen.Shop(this);
                    Console.Clear();
                }
            }
        }
        public void Death(Board b)//Kicks player out to the Main menu is health reaches 0.
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("BIG OOF, YOU HAVE DIED!");
            Console.ReadKey(true);
            Console.Clear();
        }
        public void PlayerHUD()//Prints the player info in the HUD area of the screen
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(73, 5);
            Console.Write("Name: " + Name);
            //Console.SetCursorPosition(70, 6);
            //Console.Write(History);
            Console.SetCursorPosition(73, 7);
            Console.Write("Attack: " + Attack);
            Console.SetCursorPosition(73, 8);
            Console.Write("Defense: " + Defense);
            Console.SetCursorPosition(73, 9);
            if(Health < 10)
            {
                Console.Write("Health: 0" + Health + "/" + MaxHealth);
            }
            else
            {
                Console.Write("Health: " + Health + "/" + MaxHealth);
            }
            Console.SetCursorPosition(73, 12);
            Console.Write("Floor#: " + Floor);
            Console.SetCursorPosition(73, 13);
            Console.Write("Coins: " + Currency);

        }
        public static string HistoryGen() //picks from a list of towns and jobs for your characters hometown and job
        {
            string[] towns = { "Ardougne", "Keldagrim", "Draynor", "Lumbridge", "Varrock", "Gnome Stronghold", "Falador", "Canifis", "Morytania", "Port Sarim", "Rellekka" };
            string[] jobs = { "Woodcutter", "Miner", "Blacksmith", "Crafter", "Farmer", "Fisher", "Cook", "Inventor", "Attacker", "Healer", "Defender", "Ranger", "Mage", "Herbalist", "Priest", "Thief", "Hunter", "Pyromancer" };
            string hometown = towns[StaticRandom.Instance.Next(0, towns.Length)];
            string job = jobs[StaticRandom.Instance.Next(0, jobs.Length)];
            string history = "Hometown: " + hometown + "\nJob: " + job;
            return history;
        }
    }
}
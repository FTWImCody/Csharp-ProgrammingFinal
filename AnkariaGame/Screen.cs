using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AnkariaGame
{
    class Screen
    {
        public static void TitleScreen()//The opening screen for the game
        {
            Console.WriteLine("      ___       __   __         ___    ___  __                          __           /");
            Console.WriteLine("|  | |__  |    /  ` /  \\  |\\/| |__      |  /  \\     /\\  |\\ | |__/  /\\  |__) |  /\\   / ");
            Console.WriteLine("|/\\| |___ |___ \\__, \\__/  |  | |___     |  \\__/    /~~\\ | \\| |  \\ /~~\\ |  \\ | /~~\\ .  ");
            Console.WriteLine("                                                                                      ");
            Console.WriteLine("                          Programmed by Cody McNealy                                  ");
            Console.ReadKey(true);
            Console.Clear();
            //HomeScreen();
        }
        public static void HomeScreen()//Allows character to start new game, load game, change settings or exit
        {
            Console.WriteLine("  __    _      _      __    ___   _    __   ");
            Console.WriteLine(" / /\\  | |\\ | | |_/  / /\\  | |_) | |  / /\\  ");
            Console.WriteLine("/_/--\\ |_| \\| |_| \\ /_/--\\ |_| \\ |_| /_/--\\ ");
            Console.WriteLine("\n1) New Game");
            Console.WriteLine("2) Exit Game");
            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey(true);
                char userInput = char.ToUpper(k.KeyChar);
                if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
                {
                    break;
                }
                if (k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for playing my game!");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
            }
            Console.Clear();
        }
        public static void Shop(Player p)//Opens the traveling merchant shop
        {
            
            Console.Clear();
            Console.WriteLine(" _____                     _ _                                    _                 _   ");
            Console.WriteLine("/__   \\_ __ __ ___   _____| (_)_ __   __ _    /\\/\\   ___ _ __ ___| |__   __ _ _ __ | |_ ");
            Console.WriteLine("  / /\\/ '__/ _` \\ \\ / / _ \\ | | '_ \\ / _` |  /    \\ / _ \\ '__/ __| '_ \\ / _` | '_ \\| __|");
            Console.WriteLine(" / /  | | | (_| |\\ V /  __/ | | | | | (_| | / /\\/\\ \\  __/ | | (__| | | | (_| | | | | |_ ");
            Console.WriteLine(" \\/   |_|  \\__,_| \\_/ \\___|_|_|_| |_|\\__, | \\/    \\/\\___|_|  \\___|_| |_|\\__,_|_| |_|\\__|");
            Console.WriteLine("                                     |___/                                              \n\n");
            Console.WriteLine("1) Scroll of Annihilation(Kills all of one type of Monster on the board!) - 5000 Coins");
            Console.WriteLine("2) Small Healing Potion(Heals between 2-4 Health) - 50 Coins");
            Console.WriteLine("3) Medium Healing Potion(Heals between 5-10 Health - 150 Coins");
            Console.WriteLine("4) Large Healing Potion(Heals to max Health) - 500 Coins\n");
            Console.WriteLine("You have " + p.Currency + " coins to spend.");
            Console.WriteLine("Select one of the above or E to Exit: ");
            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey(true);
                char userInput = char.ToUpper(k.KeyChar);
                if(k.Key == ConsoleKey.E)
                {
                    break;
                }
                else if(k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
                {
                    if(p.Currency >= 5000)
                    {
                        p.ScrollOfAnn++;
                        p.Currency -= 5000;
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You purchase 1x Scroll of Annihilation!");
                        Console.ReadKey();
                        Console.SetCursorPosition(0, 13);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You have " + p.Currency + " coins to spend.");
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You don't have enough for this item! You need 5000 coins!");
                        Console.ReadKey();
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();

                    }
                }
                else if(k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
                {
                    if(p.Currency >= 50)
                    {
                        p.SmallPot++;
                        p.Currency -= 50;
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You purchase 1x Small Potion!");
                        Console.ReadKey();
                        Console.SetCursorPosition(0, 13);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You have " + p.Currency + " coins to spend.");
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You don't have enough for this item! You need 50 coins!");
                        Console.ReadKey();
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                    }
                }
                else if (k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D3)
                {
                    if (p.Currency >= 150)
                    {
                        p.MedPot++;
                        p.Currency -= 150;
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You purchase 1x Medium Potion!");
                        Console.ReadKey();
                        Console.SetCursorPosition(0, 13);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You have " + p.Currency + " coins to spend.");
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You don't have enough for this item! You need 150 coins!");
                        Console.ReadKey();
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                    }
                }
                else if (k.Key == ConsoleKey.NumPad4 || k.Key == ConsoleKey.D4)
                {
                    if (p.Currency >= 500)
                    {
                        p.LrgPot++;
                        p.Currency -= 500;
                        Console.SetCursorPosition(0, 14);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You purchase 1x Large Potion!");
                        Console.ReadKey();
                        Console.SetCursorPosition(0, 13);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You have " + p.Currency + " coins to spend.");
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You don't have enough for this item! You need 500 coins!");
                        Console.ReadKey();
                        Console.SetCursorPosition(0, 15);
                        Utilities.ClearCurrentConsoleLine();
                    }
                }
            }
        }
        public static void CSheet(Player p)//Opens Character sheet where the player can view their stats
        {
            Console.Clear();
            Console.WriteLine("Name: " + p.Name);
            Console.WriteLine(p.History);
            Console.WriteLine("Attack: " + p.Attack);
            Console.WriteLine("Defense: " + p.Defense);
            Console.WriteLine("Health: " + p.Health + "/" + p.MaxHealth);
            Console.WriteLine("Floor: " + p.Floor);
            Console.WriteLine("Coins: " + p.Currency);
            Console.ReadKey(true);
            Console.Clear();
        }
        public static void Backpack(Player p, Board b)//Allows user to view/use items in their backpack
        {
            Inventory(p);
            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey(true);
                char userInput = char.ToUpper(k.KeyChar);
                if (k.Key == ConsoleKey.E || k.Key == ConsoleKey.B)
                {
                    break;
                }
                else if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)//Uses Scroll and allows user to remove all monsters with the same Symbol using LINQ..
                {
                    if (p.ScrollOfAnn == 0)
                    {
                        Console.SetCursorPosition(0, 14);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You don't have any Scrolls of Annihilation to use!");
                        Console.ReadKey(true);
                        Console.SetCursorPosition(0, 14);
                        Utilities.ClearCurrentConsoleLine();
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 14);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("What monster would you like to Annihilate? (Type the Symbol):");
                        List<Monster> dm = new List<Monster>();
                        string userinput = Console.ReadLine().ToUpper();
                        IEnumerable<Monster> query = from m in b.MonsterList where m.Symbol == userinput select m;

                        foreach (Monster m in query)
                        {
                            m.Death(b);
                            dm.Add(m);
                        }
                        if (query.Count() == 0)
                        {
                            Console.SetCursorPosition(0, 15);
                            Utilities.ClearCurrentConsoleLine();
                            Console.WriteLine("There are no Symbols of" + userinput + " on the board!");
                        }
                        else
                        {
                            foreach (Monster m in dm)
                            {
                                b.MonsterList.Remove(m);
                            }
                            Console.SetCursorPosition(0, 36);
                            Utilities.ClearCurrentConsoleLine();
                            Console.SetCursorPosition(0, 15);
                            Utilities.ClearCurrentConsoleLine();
                            Console.WriteLine("All monsters with the Symbol " + userinput + " are dead!");
                            Console.ReadKey(true);
                            p.ScrollOfAnn--;
                            Inventory(p);
                        }
                    }
                    Console.SetCursorPosition(0, 14);
                    Utilities.ClearCurrentConsoleLine();
                    Console.SetCursorPosition(0, 15);
                    Utilities.ClearCurrentConsoleLine();
                }
                else if (k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
                {
                    if (p.SmallPot == 0)
                    {
                        Console.SetCursorPosition(0, 14);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You don't have any Small Potions to use!");
                        Console.ReadKey(true);
                        Console.SetCursorPosition(0, 14);
                        Utilities.ClearCurrentConsoleLine();
                    }
                    else
                    {
                        if (p.Health >= p.MaxHealth)
                        {
                            Console.SetCursorPosition(0, 14);
                            Utilities.ClearCurrentConsoleLine();
                            Console.WriteLine("You can not heal past your max health of " + p.MaxHealth);
                        }
                        else
                        {
                            int smHealing = StaticRandom.Instance.Next(2, 5);
                            p.Health += smHealing;
                            if(p.Health > p.MaxHealth)
                            {
                                p.Health = p.MaxHealth;
                            }
                            p.SmallPot--;
                            Console.SetCursorPosition(0, 14);
                            Utilities.ClearCurrentConsoleLine();
                            Console.WriteLine("You heal for " + smHealing + " Health!");
                            Console.ReadKey(true);
                            Console.Clear();
                            Inventory(p);
                        }
                    }
                }
                else if (k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D3)
                {
                    if (p.MedPot == 0)
                    {
                        Console.SetCursorPosition(0, 14);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You don't have any Medium Potions to use!");
                        Console.ReadKey(true);
                        Console.SetCursorPosition(0, 14);
                        Utilities.ClearCurrentConsoleLine();
                    }
                    else
                    {
                        if (p.Health >= p.MaxHealth)
                        {
                            Console.SetCursorPosition(0, 14);
                            Utilities.ClearCurrentConsoleLine();
                            Console.WriteLine("You can not heal past your max health of " + p.MaxHealth);
                        }
                        else
                        {
                            int mdHealing = StaticRandom.Instance.Next(5, 11);
                            p.Health += mdHealing;
                            if (p.Health > p.MaxHealth)
                            {
                                p.Health = p.MaxHealth;
                            }
                            p.MedPot--;
                            Console.SetCursorPosition(0, 14);
                            Utilities.ClearCurrentConsoleLine();
                            Console.WriteLine("You heal for " + mdHealing + " Health!");
                            Console.ReadKey(true);
                            Console.Clear();
                            Inventory(p);
                        }
                    }

                }
                else if (k.Key == ConsoleKey.NumPad4 || k.Key == ConsoleKey.D4)
                {
                    if (p.LrgPot == 0)
                    {
                        Console.SetCursorPosition(0, 14);
                        Utilities.ClearCurrentConsoleLine();
                        Console.WriteLine("You don't have any Large Potions to use!");
                        Console.ReadKey(true);
                        Console.SetCursorPosition(0, 14);
                        Utilities.ClearCurrentConsoleLine();
                    }
                    else
                    {
                        if (p.Health >= p.MaxHealth)
                        {
                            Console.SetCursorPosition(0, 14);
                            Utilities.ClearCurrentConsoleLine();
                            Console.WriteLine("You can not heal past your max health of " + p.MaxHealth);
                        }
                        else
                        {
                            int lgHealing = p.MaxHealth - p.Health;
                            p.Health = p.MaxHealth;
                            p.LrgPot--;
                            Console.SetCursorPosition(0, 14);
                            Utilities.ClearCurrentConsoleLine();
                            Console.WriteLine("You heal for " + lgHealing + " Health!");
                            Console.ReadKey(true);
                            Console.Clear();
                            Inventory(p);
                        }
                    }
                }
            }
            Console.Clear();
        }
        public static void HelpScreen()//Shows all of the in-game controls/info
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("            _       ");
                Console.WriteLine("  /\\  /\\___| |_ __  ");
                Console.WriteLine(" / /_/ / _ \\ | '_ \\ ");
                Console.WriteLine("/ __  /  __/ | |_) |");
                Console.WriteLine("\\/ /_/ \\___|_| .__/ ");
                Console.WriteLine("             |_|    \n");
                Console.WriteLine("Use WASD | NumPad1-9 | ArrowKeys for movement...");
                Console.WriteLine("B for Backpack");
                Console.WriteLine("C for Character Sheet\n");
                Console.WriteLine("Game Objects: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("- Stairs to the next Floor.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("I ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("- Items, 5-10 Coins dropped by monsters.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("T ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("- Traveling Merchant, sells Scrolls of Annihilation and Potions.\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("N ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("- Necromancer, can spawn up to 3 Zombies and stands still once it summons.");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Z ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("- Zombie, when you walk in range it will follow you around the board unless you get out of range.\n");
                Console.WriteLine("Press ESC to quit the game");
                Console.WriteLine("Press E to Exit");
                ConsoleKeyInfo k = Console.ReadKey(true);
                char userInput = char.ToUpper(k.KeyChar);
                if (k.Key == ConsoleKey.E || k.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    break;
                }
                else if(k.Key == ConsoleKey.Escape)
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
            }
        }
        public static void Inventory(Player p)//The GUI for the inventory
        {
            Console.Clear();
            Console.WriteLine("  _____                      _                   ");
            Console.WriteLine("  \\_   \\_ ____   _____ _ __ | |_ ___  _ __ _   _ ");
            Console.WriteLine("   / /\\/ '_ \\ \\ / / _ \\ '_ \\| __/ _ \\| '__| | | |");
            Console.WriteLine("/\\/ /_ | | | \\ V /  __/ | | | || (_) | |  | |_| |");
            Console.WriteLine("\\____/ |_| |_|\\_/ \\___|_| |_|\\__\\___/|_|   \\__, |");
            Console.WriteLine("                                           |___/ \n");
            Console.WriteLine("1) You have " + p.ScrollOfAnn + " Scroll(s) of Annihilation to use.");
            Console.WriteLine("2) You have " + p.SmallPot + " Small Potions to use. (Heals 2-4)");
            Console.WriteLine("3) You have " + p.MedPot + " Medium Potions to use. (Heals 5-10)");
            Console.WriteLine("4) You have " + p.LrgPot + " Large Potions to use. (Heals to Max)");
            Console.WriteLine("Select one of the above or E to Exit: ");
        }
        public static void Goal()//Prints the goal of the game before player starts it
        {
            Console.WriteLine("   ___            _ ");
            Console.WriteLine("  / _ \\___   __ _| |");
            Console.WriteLine(" / /_\\/ _ \\ / _` | |");
            Console.WriteLine("/ /_\\  (_) | (_| | |");
            Console.WriteLine("\\____/\\___/ \\__,_|_|\n\n");
            Console.WriteLine("You are tasked with the mission of going into a dungeon full of Necromancer's and your goal is to get\nas far into the Dungeon to find the Mythical Amulet.\n");
            Console.WriteLine("NOTE: There is no Mythical Amulet..it goes on endlessly..\nThe real goal is to figure out how far you can go into the Dungeon before dying.\n");
            Console.WriteLine("ARE YOU READY?!?");
            Console.WriteLine("Press ANY key to Continue..");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
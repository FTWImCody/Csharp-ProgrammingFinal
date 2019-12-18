using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 37);
            Console.CursorVisible = false;
            int Row  = 36; //Setting height
            int Col = 36;  //and width of board..
            Screen.TitleScreen(); //Opening screen for the game
            while (true) {
                Console.ForegroundColor = ConsoleColor.White;
                Screen.HomeScreen(); 
                Player p = Player.PlayerCreation(); //Allows Player to select their name and roll for stats..
                Screen.Goal();
                Shopkeeper tm = new Shopkeeper();
                Board GameBoard = new Board(Row, Col, 10); //Creates an empty board with 36 rows, 36 columnns and 10 rooms
                GameBoard.MonsterList = Monster.GenMon(GameBoard, 1); //creates a list of Monsters to loop through for movement and placement
                GameBoard.PlaceActor(Row, Col, p); //Places the player
                GameBoard.PlaceActor(Row, Col, tm); //Places the traveling merchant
                GameBoard.PlaceStairs(Row, Col, p);
                for (int i = 0; i < GameBoard.MonsterList.Count(); i++)//Loops through MonsterList to place Monsters on the board..
                {
                    GameBoard.PlaceActor(Row, Col, GameBoard.MonsterList[i]);
                }
                while (true) //Main gameplay loop
                {
                    p.PlayerHUD(); //Shows players info on the right hand side of the board
                    GameBoard.ShowBoard();
                    if (p.Health <= 0)
                    {
                        p.Death(GameBoard);
                        break;
                    }
                    else
                    {
                        p.Move(GameBoard);
                    }
                    if (GameBoard.GameBoard[p.Col, p.Row].StairsHere == true) //If player reaches the stairs, adds coins to currency based on floor number, then it generates a new board, places player and generates a new list of Monsters and places them on the board.
                    {
                        if (p.Floor <= 5)
                        {
                            p.Currency += p.Floor * 50;
                        }
                        else if (p.Floor <= 10)
                        {
                            p.Currency += p.Floor * 40;
                        }
                        else if (p.Floor <= 15)
                        {
                            p.Currency += p.Floor * 30;
                        }
                        else if (p.Floor <= 20)
                        {
                            p.Currency += p.Floor * 20;
                        }
                        else
                        {
                            p.Currency += p.Floor * 10;
                        }
                        p.Floor++; //Increases the floor ticker on playerHUD
                        GameBoard = new Board(Row, Col, 10);
                        GameBoard.PlaceActor(Row, Col, p);
                        if ((p.Floor % 5) == 0)
                        {
                            GameBoard.PlaceActor(Row, Col, tm);
                        }
                        GameBoard.PlaceStairs(Row, Col, p);
                        GameBoard.MonsterList.Clear();
                        GameBoard.MonsterList = Monster.GenMon(GameBoard, 1);

                        for (int i = 0; i < GameBoard.MonsterList.Count(); i++)//Loops through MonsterList to place Monsters on the board..
                        {
                            GameBoard.PlaceActor(Row, Col, GameBoard.MonsterList[i]);
                        }
                    }

                    else
                    {
                        for (int i = 0; i < GameBoard.MonsterList.Count(); i++) //Loops through MonsterList and checks if Health <= 0: if so then removes character, if not then moves the character
                        {
                            if (GameBoard.MonsterList[i].Health <= 0)
                            {
                                GameBoard.MonsterList[i].Death(GameBoard);
                                GameBoard.MonsterList.Remove(GameBoard.MonsterList[i]);
                                continue;
                            }
                            GameBoard.MonsterList[i].Move(GameBoard, p);
                        }
                        if (GameBoard.GameBoard[p.Col, p.Row].CoinsHere == true)
                        {
                            p.Currency += StaticRandom.Instance.Next(5, 11);
                            GameBoard.GameBoard[p.Col, p.Row].CoinsHere = false;
                        }
                    }
                }
            }
        }
    }
}
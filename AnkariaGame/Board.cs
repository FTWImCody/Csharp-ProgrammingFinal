using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkariaGame
{
    class Board
    {
        public int Row { get; }
        public int Col { get; }
        public Tile[,] GameBoard { get; set; }
        private List<int[]> _MIDPOINTS = new List<int[]>();
        public List<Monster> MonsterList = new List<Monster> { }; //MonsterList stored in Board for easier access
        public int PRow { get; set; } //Player Row stored in Board for easier access
        public int PCol { get; set; } //Player Col stored in Board for easier access

        //CONSTRUCTOR
        public Board(int r, int c, int numOfRooms)
        {
            Row = r;
            Col = c;
            GameBoard = new Tile[Row, Col];
            BlankBoard(r, c); //Creates an empty board of Tiles(Empty tiles are #).
            CreateRooms(r, c, numOfRooms); //Carves out number of rooms into the blank board leaving 1 border around.
            ConnectRooms();
        }
        public void BlankBoard(int Row, int Col)//Creates a board of empty tiles with size Row by Col.
        {
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Col; j++)
                    GameBoard[i, j] = new Tile(c: ConsoleColor.Blue);
        }
        public void CreateRooms(int Row, int Col, int numOfRooms)//Creates numOfRooms using Row and Col of board.
        {
            int roomCounter = 0;
            while (numOfRooms > roomCounter)
            {
                int randRow = StaticRandom.Instance.Next(1, Row);
                int randCol = StaticRandom.Instance.Next(1, Col);
                int randR = StaticRandom.Instance.Next(5, 8);
                int randC = StaticRandom.Instance.Next(5, 8);
                if (CheckRoom(randRow, randCol, randC, randR, Row, Col) == true) //Checks if the coordinates are valid coordinates and if it leaves a border of 1 around the game board
                {
                    MakeRoom(randRow, randCol, randC, randR); //Carves a room using the valid coordinates
                    numOfRooms--;
                    int[] midpoint = new int[2];
                    midpoint[0] = randRow + (randR / 2);
                    midpoint[1] = randCol + (randC / 2);
                    _MIDPOINTS.Add(midpoint); //Stores midpoint[0]&[1] into a _MIDPOINTS List
                }
                else
                {
                    continue;
                }
            }
        }
        public bool CheckRoom(int randRow, int randCol, int Col, int Row, int bHeight, int bLength)//Checks if the room is in the board and not at the edge of the board.
        {
            if (randRow + Row < bHeight && randCol + Col < bLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void MakeRoom(int row, int col, int length, int height)//Actually creates the room on the board and changes the Symbols, Color..
        {

            for (int i = row; i < row + height; i++)
            {
                for (int j = col; j < col + length; j++)
                {
                    GameBoard[i, j].Symbol = ".";
                    GameBoard[i, j].Color = ConsoleColor.Yellow;
                }
            }
        }
        public void ConnectRooms()//Creates corridors to connect all the rooms together, so the player could access all the rooms.
        {
            /*Check _MIDPOINTS[0][0] to _MIDPOINTS[1][0]
             * Then check _MIDPOINTS[0][1] to _MIDPOINTS[1][1]
             */
            int coinFlip = StaticRandom.Instance.Next(1, 3);
            switch (coinFlip)
            {
                case 1:
                    for (int i = 0; i < _MIDPOINTS.Count() - 1; i++)
                    {
                        int CurrentTileCol = _MIDPOINTS[i][0];
                        int CurrentTileRow = _MIDPOINTS[i][1];
                        while (CurrentTileCol != _MIDPOINTS[i + 1][0])
                        {
                            if (CurrentTileCol > _MIDPOINTS[i + 1][0])
                            {
                                CurrentTileCol--;
                                GameBoard[CurrentTileCol, CurrentTileRow].Symbol = ".";
                                GameBoard[CurrentTileCol, CurrentTileRow].Color = ConsoleColor.Yellow;
                            }
                            else
                            {
                                CurrentTileCol++;
                                GameBoard[CurrentTileCol, CurrentTileRow].Symbol = ".";
                                GameBoard[CurrentTileCol, CurrentTileRow].Color = ConsoleColor.Yellow;
                            }
                        }
                        while (CurrentTileRow != _MIDPOINTS[i + 1][1])
                        {
                            if (CurrentTileRow > _MIDPOINTS[i + 1][1])
                            {
                                CurrentTileRow--;
                                GameBoard[CurrentTileCol, CurrentTileRow].Symbol = ".";
                                GameBoard[CurrentTileCol, CurrentTileRow].Color = ConsoleColor.Yellow;
                            }
                            else
                            {
                                CurrentTileRow++;
                                GameBoard[CurrentTileCol, CurrentTileRow].Symbol = ".";
                                GameBoard[CurrentTileCol, CurrentTileRow].Color = ConsoleColor.Yellow;
                            }
                        }
                    }
                    break;
                default:
                    for (int i = 0; i < _MIDPOINTS.Count() - 1; i++)
                    {
                        int CurrentTileCol = _MIDPOINTS[i][0];
                        int CurrentTileRow = _MIDPOINTS[i][1];
                        while (CurrentTileRow != _MIDPOINTS[i + 1][1])
                        {
                            if (CurrentTileRow > _MIDPOINTS[i + 1][1])
                            {
                                CurrentTileRow--;
                                GameBoard[CurrentTileCol, CurrentTileRow].Symbol = ".";
                                GameBoard[CurrentTileCol, CurrentTileRow].Color = ConsoleColor.Yellow;
                            }
                            else
                            {
                                CurrentTileRow++;
                                GameBoard[CurrentTileCol, CurrentTileRow].Symbol = ".";
                                GameBoard[CurrentTileCol, CurrentTileRow].Color = ConsoleColor.Yellow;
                            }
                        }
                        while (CurrentTileCol != _MIDPOINTS[i + 1][0])
                        {
                            if (CurrentTileCol > _MIDPOINTS[i + 1][0])
                            {
                                CurrentTileCol--;
                                GameBoard[CurrentTileCol, CurrentTileRow].Symbol = ".";
                                GameBoard[CurrentTileCol, CurrentTileRow].Color = ConsoleColor.Yellow;
                            }
                            else
                            {
                                CurrentTileCol++;
                                GameBoard[CurrentTileCol, CurrentTileRow].Symbol = ".";
                                GameBoard[CurrentTileCol, CurrentTileRow].Color = ConsoleColor.Yellow;
                            }
                        }
                    }
                    break;

            }
            
        }
        public void PlaceStairs(int r, int c, Player p)//Chooses a random point to place stairs and checks to make sure it's in a room/corridor.
        {
            while(true) {
                int randColStairs = StaticRandom.Instance.Next(1, c);
                int randRowStairs = StaticRandom.Instance.Next(1, r);
                double distance = Utilities.Distance(randRowStairs, randRowStairs, p.Row, p.Col);

                if (GameBoard[randRowStairs, randColStairs].Symbol == "." && distance > 15)
                {
                    GameBoard[randRowStairs, randColStairs].StairsHere = true;
                    GameBoard[randRowStairs, randColStairs].Color = ConsoleColor.Red;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        public void PlaceActor(int r, int c, IActor a)//Chooses a random point to place a player and checks to make sure it's in a room/corridor and not stairs.
        {
            while (true) {
                int randXPlr = StaticRandom.Instance.Next(0, c);
                int randYPlr = StaticRandom.Instance.Next(0, r);

                if (GameBoard[randYPlr, randXPlr].Symbol == "." && GameBoard[randYPlr, randXPlr].StairsHere == false && GameBoard[randYPlr, randXPlr].Occupied == null && a is Player)
                {
                    GameBoard[randYPlr, randXPlr].Occupied = a;
                    a.Row = randXPlr;
                    a.Col = randYPlr;
                    this.PRow = randXPlr;
                    this.PCol = randYPlr;
                    break;
                }
                else if(GameBoard[randYPlr, randXPlr].Symbol == "." && GameBoard[randYPlr, randXPlr].StairsHere == false && GameBoard[randYPlr, randXPlr].Occupied == null)
                {
                    GameBoard[randYPlr, randXPlr].Occupied = a;
                    a.Row = randXPlr;
                    a.Col = randYPlr;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        public void DisplayTile(int h, int l)//Checks to see if Tile is not null/StairsHere/CoinsHere and writes the Symbol and Color to the board.
        {
            Console.SetCursorPosition(l*2, h);
            Console.ForegroundColor = GameBoard[h, l].Color;
            if (GameBoard[h, l].Occupied != null)
            {
                Console.ForegroundColor = GameBoard[h, l].Occupied.Color;
                Console.Write(GameBoard[h, l].Occupied.Symbol);
            }
            else if (GameBoard[h, l].StairsHere)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("<");
            }
            else if (GameBoard[h, l].CoinsHere)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("I");
            }
            else
            {
                Console.Write(GameBoard[h, l].Symbol);
            }
        }
        public void ShowBoard()//Loops through the whole board to display the board on the screen.
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    DisplayTile(i, j);
                }
            }
        }
    }
}
using System;

namespace _02.PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            int whiteRow = -1;
            int whiteCol = -1;
            int blackRow = -1;
            int blackCol = -1;


            for (int i = 0; i < board.GetLength(0); i++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (row[j] == 'w')
                    {
                        whiteRow = i;
                        whiteCol = j;
                    }

                    if (row[j] == 'b')
                    {
                        blackRow = i;
                        blackCol = j;
                    }

                    board[i, j] = row[j];
                }
            }

            bool isWhite = true;

            while (true)
            {
                if (isWhite)
                {
                    board[whiteRow, whiteCol] = '-';

                    for (int i = -1; i < 2; i += 2)
                    {
                        for (int j = -1; j < 2; j += 2)
                        {
                            if (IsInMatrix(board, whiteRow + i, whiteCol + j))
                            {
                                if (blackRow == whiteRow + i && blackCol == whiteCol + j)
                                {
                                    Console.WriteLine($"Game over! White capture on {GetCoordinates(blackRow, blackCol)}.");
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }

                    whiteRow--;

                    //Check if promoted
                    if (whiteRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {GetCoordinates(whiteRow, whiteCol)}.");
                        Environment.Exit(0);
                    }

                    board[whiteRow, whiteCol] = 'w';
                    isWhite = false;
                }
                else
                {
                    board[blackRow, blackCol] = '-';

                    for (int i = -1; i < 2; i += 2)
                    {
                        for (int j = -1; j < 2; j += 2)
                        {
                            if (IsInMatrix(board, blackRow + i, blackCol + j))
                            {
                                if (whiteRow == blackRow + i && whiteCol == blackCol + j)
                                {
                                    Console.WriteLine($"Game over! Black capture on {GetCoordinates(whiteRow, whiteCol)}.");
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }

                    blackRow++;

                    if (blackRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {GetCoordinates(blackRow, blackCol)}.");
                        Environment.Exit(0);
                    }

                    board[blackRow, blackCol] = 'b';
                    isWhite = true;
                }
            }
        }

        static string GetCoordinates(int row, int col)
        {
            string coordinates = "";
            coordinates += ((char)(97 + col));
            coordinates += 8 - row;
            return coordinates;
        }

        static bool IsInMatrix<T>(T[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}

using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] bakery = new char[size, size];
            int[] playerCoordinates = new int[2];

            for (int i = 0; i < bakery.GetLength(0); i++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                for (int j = 0; j < bakery.GetLength(1); j++)
                {
                    if (row[j] == 'S')
                    {
                        playerCoordinates[0] = i;
                        playerCoordinates[1] = j;
                    }

                    bakery[i, j] = row[j];
                }
            }

            int money = 0;

            while (money < 50)
            {
                string direction = Console.ReadLine();

                bakery[playerCoordinates[0], playerCoordinates[1]] = '-';

                if (direction == "up")
                {
                    playerCoordinates[0]--;
                }
                else if (direction == "down")
                {
                    playerCoordinates[0]++;
                }
                else if (direction == "left")
                {
                    playerCoordinates[1]--;
                }
                else if (direction == "right")
                {
                    playerCoordinates[1]++;
                }

                if (IsInMatrix(bakery, playerCoordinates[0], playerCoordinates[1]))
                {
                    if (int.TryParse(bakery[playerCoordinates[0], playerCoordinates[1]].ToString(), out int client))
                    {
                        money += client;
                    }
                    else if (bakery[playerCoordinates[0], playerCoordinates[1]] == 'O')
                    {
                        for (int row = 0; row < bakery.GetLength(0); row++)
                        {
                            for (int col = 0; col < bakery.GetLength(1); col++)
                            {
                                if (bakery[row, col] == 'O' &&
                                    row != playerCoordinates[0] && col != playerCoordinates[1])
                                {
                                    bakery[playerCoordinates[0], playerCoordinates[1]] = '-';
                                    playerCoordinates[0] = row;
                                    playerCoordinates[1] = col;
                                }
                            }
                        }
                    }

                    bakery[playerCoordinates[0], playerCoordinates[1]] = 'S';
                }
                else
                {
                    break;
                }
            }

            if (money < 50)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");

            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsInMatrix<T>(T[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}

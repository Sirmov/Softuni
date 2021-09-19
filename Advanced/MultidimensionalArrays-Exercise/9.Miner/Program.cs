using System;
using System.Linq;

namespace _9.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] mine = new char[size, size];
            int[] miner = new int[2];
            int totalCoals = 0;

            string[] commands = Console.ReadLine().Split();

            for (int row = 0; row < mine.GetLength(0); row++)
            {
                char[] line = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < mine.GetLength(1); col++)
                {
                    mine[row, col] = line[col];

                    if (line[col] == 's')
                    {
                        miner[0] = row;
                        miner[1] = col;
                    }
                    else if (line[col] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }

            int coal = 0;

            foreach (var command in commands)
            {
                MoveMiner(mine, miner, command);

                if (mine[miner[0], miner[1]] == 'c')
                {
                    coal++;
                    mine[miner[0], miner[1]] = '*';

                    if (coal == totalCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({miner[0]}, {miner[1]})");
                        Environment.Exit(0);
                    }
                }
                else if (mine[miner[0], miner[1]] == 'e')
                {
                    Console.WriteLine($"Game over! ({miner[0]}, {miner[1]})");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine($"{totalCoals - coal} coals left. ({miner[0]}, {miner[1]})");
        }

        private static void MoveMiner(char[,] mine, int[] miner, string command)
        {
            switch (command)
            {
                case "left":
                    if (isInMatrix(mine, miner[0], miner[1] - 1))
                    {
                        miner[1] -= 1;
                    }
                    break;
                case "right":
                    if (isInMatrix(mine, miner[0], miner[1] + 1))
                    {
                        miner[1] += 1;
                    }
                    break;
                case "up":
                    if (isInMatrix(mine, miner[0] - 1, miner[1]))
                    {
                        miner[0] -= 1;
                    }
                    break;
                case "down":
                    if (isInMatrix(mine, miner[0] + 1, miner[1]))
                    {
                        miner[0] += 1;
                    }
                    break;
            }
        }

        static bool isInMatrix(char[,] matrix, int row, int col)
        {
            if (row < 0 || row > matrix.GetLength(0) - 1 ||
                col < 0 || col > matrix.GetLength(1) - 1)
            {
                return false;
            }

            return true;
        }
    }
}

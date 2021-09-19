using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] lair = new char[sizes[0], sizes[1]];
            int[] player = new int[2];

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (line[col] == 'P')
                    {
                        player[0] = row;
                        player[1] = col;
                        lair[row, col] = '.';
                    }
                    else
                    {
                        lair[row, col] = line[col];
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();
            bool hasWon = false;
            bool hasDied = false;
            int wonRow = -1;
            int wonCol = -1;

            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'U':
                        player[0] -= 1;
                        wonRow = player[0] + 1;
                        wonCol = player[1];
                        break;
                    case 'D':
                        player[0] += 1;
                        wonRow = player[0] - 1;
                        wonCol = player[1];
                        break;
                    case 'L':
                        player[1] -= 1;
                        wonRow = player[0];
                        wonCol = player[1] + 1;
                        break;
                    case 'R':
                        player[1] += 1;
                        wonRow = player[0];
                        wonCol = player[1] - 1;
                        break;
                }

                if (!isInMatrix(lair, player[0], player[1]))
                {
                    hasWon = true;
                }
                else
                {
                    if (lair[player[0], player[1]] == 'B')
                    {
                        hasDied = true;
                    }
                }


                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            for (int i = -1; i < 2; i += 2)
                            {
                                if (isInMatrix(lair, row + i, col))
                                {
                                    if (lair[row + i, col] != 'B')
                                    {
                                        lair[row + i, col] = 'b';
                                    }

                                    if (row + i == player[0] && col == player[1])
                                    {
                                        hasDied = true;
                                    }
                                }

                                if (isInMatrix(lair, row, col + i))
                                {
                                    if (lair[row, col + i] != 'B')
                                    {
                                        lair[row, col + i] = 'b';
                                    }

                                    if (row == player[0] && col + 1 == player[1])
                                    {
                                        hasDied = true;
                                    }
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < lair.GetLength(0); i++)
                {
                    for (int j = 0; j < lair.GetLength(1); j++)
                    {
                        if (lair[i, j] == 'b')
                        {
                            lair[i, j] = 'B';
                        }
                    }
                }

                for (int i = 0; i < lair.GetLength(0); i++)
                {
                    for (int j = 0; j < lair.GetLength(1); j++)
                    {
                        if (lair[i, j] == 'B')
                        {
                            if (i == player[0] && j == player[1])
                            {
                                hasDied = true;
                            }
                        }
                    }

                    if (hasDied)
                    {
                        PrintMatrix(lair);
                        Console.WriteLine($"dead: {player[0]} {player[1]}");
                        Environment.Exit(0);
                    }

                    if (hasWon)
                    {
                        PrintMatrix(lair);
                        Console.WriteLine($"won: {wonRow} {wonCol}");
                        Environment.Exit(0);
                    }
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

            static void PrintMatrix(char[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}

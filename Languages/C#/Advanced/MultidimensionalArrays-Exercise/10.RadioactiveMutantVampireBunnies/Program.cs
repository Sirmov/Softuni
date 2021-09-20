using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
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

            foreach (var command in commands)
            {
                MovePlayer(lair, player, command);
                ReplicateBunnies(lair, player);
            }
        }

        private static void ReplicateBunnies(char[,] lair, int[] player)
        {
            GiveBirth(lair);
            GrowBabies(lair);
            CheckPlayer(lair, player);
        }

        private static void CheckPlayer(char[,] lair, int[] player)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        if (row == player[0] && col == player[1])
                        {
                            Die(lair, player, false);
                        }
                    }
                }
            }
        }

        private static void GrowBabies(char[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'b')
                    {
                        lair[row, col] = 'B';
                    }
                }
            }
        }

        private static void GiveBirth(char[,] lair)
        {
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
                            }

                            if (isInMatrix(lair, row, col + i))
                            {
                                if (lair[row, col + i] != 'B')
                                {
                                    lair[row, col + i] = 'b';
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void MovePlayer(char[,] lair, int[] player, char command)
        {
            switch (command)
            {
                case 'U':
                    player[0] -= 1;

                    if (!isInMatrix(lair, player[0], player[1]))
                    {
                        Win(lair, player, player[0] + 1, player[1]);
                    }
                    break;
                case 'D':
                    player[0] += 1;

                    if (!isInMatrix(lair, player[0], player[1]))
                    {
                        Win(lair, player, player[0] - 1, player[1]);
                    }
                    break;
                case 'L':
                    player[1] -= 1;

                    if (!isInMatrix(lair, player[0], player[1]))
                    {
                        Win(lair, player, player[0], player[1] + 1);
                    }
                    break;
                case 'R':
                    player[1] += 1;

                    if (!isInMatrix(lair, player[0], player[1]))
                    {
                        Win(lair, player, player[0], player[1] - 1);
                    }
                    break;
            }

            if (lair[player[0], player[1]] == 'B')
            {
                Die(lair, player, true);
            }
        }

        private static void Die(char[,] lair, int[] player, bool replicateBunnies)
        {
            if (replicateBunnies)
            {
                ReplicateBunnies(lair, player);
            }
            PrintMatrix(lair);
            Console.WriteLine($"dead: {player[0]} {player[1]}");
            Environment.Exit(0);
        }

        private static void Win(char[,] lair, int[] player, int row, int col)
        {
            ReplicateBunnies(lair, player);
            PrintMatrix(lair);
            Console.WriteLine($"won: {row} {col}");
            Environment.Exit(0);
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

        private static void PrintMatrix(char[,] matrix)
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

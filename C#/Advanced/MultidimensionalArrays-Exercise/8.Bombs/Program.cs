using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            List<Bomb> bombs = Console.ReadLine().Split().Select(x => new Bomb(x)).ToList();
            bool flag = false;

            while (bombs.Count > 0)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (bombs.Count == 0)
                        {
                            flag = true;
                            break;
                        }

                        if (row == bombs[0].Row && col == bombs[0].Col)
                        {
                            if (matrix[row, col] > 0)
                            {
                                int damage = matrix[row, col];

                                for (int i = -1; i < 2; i++)
                                {
                                    for (int j = -1; j < 2; j++)
                                    {
                                        if (isInMatrix(matrix, row + i, col + j))
                                        {
                                            if (matrix[row + i, col + j] > 0)
                                            {
                                                matrix[row + i, col + j] -= damage;
                                            }
                                        }
                                    }
                                }

                                matrix[row, col] = 0;
                            }
                            
                            bombs.RemoveAt(0);
                        }
                    }

                    if (flag)
                    {
                        break;
                    }
                }
            }

            int aliveCount = 0;
            int sum = 0;

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCount++;
                    sum += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCount}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    else
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                }

                Console.WriteLine();
            }
        }

        static bool isInMatrix(int[,] matrix, int row, int col)
        {
            if (row < 0 || row > matrix.GetLength(0) - 1 ||
                col < 0 || col > matrix.GetLength(1) - 1)
            {
                return false;
            }

            return true;
        }
    }

    class Bomb
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Bomb(string cordinates)
        {
            int[] tokens = cordinates.Split(",").Select(int.Parse).ToArray();
            int row = tokens[0];
            int col = tokens[1];

            Row = row;
            Col = col;
        }
    }
}

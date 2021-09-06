using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] row = ReadIntArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = row[cols];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    int sum = matrix[rows, cols] +
                        matrix[rows, cols + 1] +
                        matrix[rows + 1, cols] +
                        matrix[rows + 1, cols + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = rows;
                        maxCol = cols;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
            Console.WriteLine(maxSum);
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}

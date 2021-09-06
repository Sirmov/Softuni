using System;
using System.Linq;

namespace _2.SumMatrixColumns
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

            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                int sum = 0;

                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    sum += matrix[rows, cols];
                }

                Console.WriteLine(sum);
            }
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}

using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArray();
            int[,] matrix = new int[size[0], size[1]];
            int sum = 0;

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] row = ReadIntArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = row[cols];
                    sum += row[cols];
                }
            }

            Console.WriteLine(size[0]);
            Console.WriteLine(size[1]);
            Console.WriteLine(sum);
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

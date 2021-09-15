using System;
using System.Linq;

namespace _3.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] row = ReadIntArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = row[cols];
                }
            }

            int primaryDiagonal = 0;

            for (int i = 0; i < size; i++)
            {
                primaryDiagonal += matrix[i, i];
            }

            Console.WriteLine(primaryDiagonal);
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}

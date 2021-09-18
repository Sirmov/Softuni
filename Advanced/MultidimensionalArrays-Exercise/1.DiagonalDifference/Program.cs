using System;
using System.Linq;

namespace _1.DiagonalDifference
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
                    matrix[row,col] = line[col];
                }
            }

            int primaryDiagonal = 0;
            for (int i = 0; i < size; i++)
            {
                primaryDiagonal += matrix[i, i];
            }

            int secondaryDiagonal = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int row = matrix.GetLength(0) - 1 - col;
                secondaryDiagonal += matrix[row, col];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}

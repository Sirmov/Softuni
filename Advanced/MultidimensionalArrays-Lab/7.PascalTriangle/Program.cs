using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] jagged = new long[rows][];

            for (int i = 0; i < rows; i++)
            {
                long[] row = new long[i + 1];

                for (int col = 0; col < row.Length; col++)
                {
                    if (IsFirstOrLast(row, col))
                    {
                        row[col] = 1;
                    }
                    else
                    {
                        row[col] = jagged[i - 1][col] + jagged[i - 1][col - 1];
                    }
                }

                jagged[i] = row;
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        static bool IsFirstOrLast(long[] array, int col)
        {
            if (col == 0 || col == array.Length - 1)
            {
                return true;
            }

            return false;
        }
    }
}

using System;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int removeCount = 0;
            int maxPower = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;

            while (maxPower != 0)
            {
                maxPower = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int power = CheckPower(matrix, row, col);

                            if (power > maxPower)
                            {
                                maxPower = power;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }

                if (maxPower > 0)
                {
                    matrix[maxRow, maxCol] = 'O';
                    removeCount++;
                }
            }

            Console.WriteLine(removeCount);
        }

        private static int CheckPower(char[,] matrix, int row, int col)
        {
            int power = 0;
            for (int i = -2; i < 3; i += 4)
            {
                for (int j = -1; j < 2; j += 2)
                {
                    if (isInMatrix(matrix, row + i, col + j))
                    {
                        if (matrix[row + i, col + j] == 'K')
                        {
                            power++;
                        }
                    }
                    if (isInMatrix(matrix, row + j, col + i))
                    {
                        if (matrix[row + j, col + i] == 'K')
                        {
                            power++;
                        }
                    }
                }
            }

            return power;
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

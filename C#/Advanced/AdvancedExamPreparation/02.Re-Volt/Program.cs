using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (row[j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }

                    matrix[i, j] = row[j];
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                string direction = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                MovePlayer(matrix, ref playerRow, ref playerCol, direction);

                matrix[playerRow, playerCol] = 'f';
            }

            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }

        static void MovePlayer(char[,] matrix, ref int playerRow, ref int playerCol, string direction)
        {
            if (direction == "up")
            {
                playerRow--;

                if (playerRow < 0)
                {
                    playerRow = matrix.GetLength(0) - 1;
                }
            }
            else if (direction == "down")
            {
                playerRow++;

                if (playerRow > matrix.GetLength(0) - 1)
                {
                    playerRow = 0;
                }
            }
            else if (direction == "left")
            {
                playerCol--;

                if (playerCol < 0)
                {
                    playerCol = matrix.GetLength(1) - 1;
                }
            }
            else if (direction == "right")
            {
                playerCol++;

                if (playerCol > matrix.GetLength(1) - 1)
                {
                    playerCol = 0;
                }
            }

            if (matrix[playerRow, playerCol] == 'B')
            {;
                MovePlayer(matrix, ref playerRow, ref playerCol, direction);
            }

            if (matrix[playerRow, playerCol] == 'T')
            {
                MovePlayer(matrix, ref playerRow, ref playerCol, OppositeDirection(direction));
            }

            if (matrix[playerRow, playerCol] == 'F')
            {
                matrix[playerRow, playerCol] = 'f';
                Console.WriteLine("Player won!");
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
        }

        static string OppositeDirection(string direction)
        {
            if (direction == "up")
            {
                return "down";
            }
            else if (direction == "down")
            {
                return "up";
            }
            else if (direction == "left")
            {
                return "right";
            }
            else if (direction == "right")
            {
                return "left";
            }

            return null;
        }

        static void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}

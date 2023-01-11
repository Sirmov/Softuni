using System;
using System.Linq;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[sizes[0], sizes[1]];
            // Can implement with queue
            string snake = Console.ReadLine();
            int snakeHead = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        matrix[row, col] = snake[snakeHead++];
                    }
                    else
                    {
                        matrix[row, matrix.GetLength(1) - 1 - col] = snake[snakeHead++];
                    }
                    
                    if (snakeHead == snake.Length)
                    {
                        snakeHead = 0;
                    }
                }
            }

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

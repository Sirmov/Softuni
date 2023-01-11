using System;
using System.Collections.Generic;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int[] marioCoordinates = new int[2];

            int rows = int.Parse(Console.ReadLine());
            char[][] maze = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                maze[i] = row;

                for (int col = 0; col < row.Length; col++)
                {
                    if (row[col] == 'M')
                    {
                        marioCoordinates[0] = i;
                        marioCoordinates[1] = col;
                        break;
                    }
                }
            }

            bool hasDied = false;
            bool hasWon = false;

            while (!hasDied && !hasWon)
            {
                string[] turnInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = turnInfo[0];
                int orcRow = int.Parse(turnInfo[1]);
                int orcCol = int.Parse(turnInfo[2]);

                maze[orcRow][orcCol] = 'B';

                int estimatedRow = 0;
                int estimatedCol = 0;

                switch (direction)
                {
                    case "W":
                        estimatedRow = marioCoordinates[0] - 1;
                        estimatedCol = marioCoordinates[1];
                        break;
                    case "S":
                        estimatedRow = marioCoordinates[0] + 1;
                        estimatedCol = marioCoordinates[1];
                        break;
                    case "A":
                        estimatedRow = marioCoordinates[0];
                        estimatedCol = marioCoordinates[1] - 1;
                        break;
                    case "D":
                        estimatedRow = marioCoordinates[0];
                        estimatedCol = marioCoordinates[1] + 1;
                        break;
                    default:
                        continue;
                }

                marioLives--;

                if (IsInJagged(maze, estimatedRow, estimatedCol))
                {
                    if (maze[estimatedRow][estimatedCol] == 'B')
                    {
                        marioLives -= 2;
                    }


                    if (maze[estimatedRow][estimatedCol] == 'P')
                    {
                        hasWon = true;
                        maze[estimatedRow][estimatedCol] = '-';
                        maze[marioCoordinates[0]][marioCoordinates[1]] = '-';
                        break;
                    }

                    if (marioLives <= 0)
                    {
                        hasDied = true;
                        maze[estimatedRow][estimatedCol] = 'X';
                        maze[marioCoordinates[0]][marioCoordinates[1]] = '-';
                        marioCoordinates[0] = estimatedRow;
                        marioCoordinates[1] = estimatedCol;
                        break;
                    }


                    maze[estimatedRow][estimatedCol] = 'M';
                    maze[marioCoordinates[0]][marioCoordinates[1]] = '-';
                    marioCoordinates[0] = estimatedRow;
                    marioCoordinates[1] = estimatedCol;
                }
            }

            if (hasDied)
            {
                Console.WriteLine($"Mario died at {marioCoordinates[0]};{marioCoordinates[1]}.");
            }
            else if (hasWon)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            }

            for (int row = 0; row < maze.Length; row++)
            {
                Console.WriteLine(new string(maze[row]));
            }
        }

        static bool IsInJagged<T>(T[][] jagged, int row, int col)
        {
            if (row >= 0 && row < jagged.Length &&
                col >= 0 && col < jagged[row].Length)
            {
                return true;
            }

            return false;
        }
    }
}

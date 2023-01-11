using System;
using System.Collections;
using System.Collections.Generic;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries));

            char[,] field = new char[fieldSize, fieldSize];
            int playerOneShips = 0;
            int playerTwoShips = 0;
            int totalDestroyedShips = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] row = Console.ReadLine().Replace(" ", "").ToCharArray();

                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (row[j] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (row[j] == '>')
                    {
                        playerTwoShips++;
                    }

                    field[i, j] = row[j];
                }
            }

            while (commands.Count > 0 && playerOneShips > 0 && playerTwoShips > 0)
            {
                string command = commands.Dequeue();
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int attackRow = int.Parse(commandArgs[0]);
                int attackCol = int.Parse(commandArgs[1]);

                if (IsInField(field, attackRow, attackCol))
                {
                    if (field[attackRow, attackCol] == '#')
                    {
                        field[attackRow, attackCol] = 'X';

                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                if (i == 0 && j == 0)
                                {
                                    continue;
                                }

                                if (IsInField(field, attackRow + i, attackCol + j))
                                {
                                    if (field[attackRow + i, attackCol + j] == '<')
                                    {
                                        field[attackRow + i, attackCol + j] = 'X';
                                        playerOneShips--;
                                        totalDestroyedShips++;
                                    }
                                    else if (field[attackRow + i, attackCol + j] == '>')
                                    {
                                        field[attackRow + i, attackCol + j] = 'X';
                                        playerTwoShips--;
                                        totalDestroyedShips++;
                                    }
                                }
                            }
                        }
                    }
                    else if (field[attackRow, attackCol] == '<')
                    {
                        field[attackRow, attackCol] = 'X';
                        playerOneShips--;
                        totalDestroyedShips++;
                    }
                    else if (field[attackRow, attackCol] == '>')
                    {
                        field[attackRow, attackCol] = 'X';
                        playerTwoShips--;
                        totalDestroyedShips++;
                    }
                }
            }

            if (playerOneShips > 0 && playerTwoShips > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
            else if (playerOneShips == 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalDestroyedShips} ships have been sunk in the battle.");
            }
            else if (playerTwoShips == 0)
            {
                Console.WriteLine($"Player One has won the game! {totalDestroyedShips} ships have been sunk in the battle.");
            }
        }

        private static bool IsInField<T>(T[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) &&
                col >= 0 && col < field.GetLength(1);
        }
    }
}

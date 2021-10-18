using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];

            for (int i = 0; i < beach.Length; i++)
            {
                char[] row = Console.ReadLine().Replace(" ", "").ToCharArray();
                beach[i] = row;
            }

            int collectedTokens = 0;
            int enemyTokens = 0;

            string command = Console.ReadLine();
            while (command != "Gong")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);

                if (operation == "Find")
                {
                    if (IsInJagged(beach, row, col))
                    {
                        if (beach[row][col] == 'T')
                        {
                            collectedTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }
                else if (operation == "Opponent")
                {
                    string direction = commandArgs[3];

                    for (int i = 0; i < 4; i++)
                    {
                        int tokens = -1;

                        if (direction == "up")
                        {
                            tokens = MoveOpponent(beach, row - i, col);
                        }
                        else if (direction == "down")
                        {
                            tokens = MoveOpponent(beach, row + i, col);
                        }
                        else if (direction == "left")
                        {
                            tokens = MoveOpponent(beach, row, col - i);
                        }
                        else if (direction == "right")
                        {
                            tokens = MoveOpponent(beach, row, col + i);
                        }

                        if (tokens == -1)
                        {
                            break;
                        }
                        else
                        {
                            enemyTokens += tokens;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var row in beach)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {enemyTokens}");
        }

        private static int MoveOpponent(char[][] beach, int row, int col)
        {
            int tokens = 0;

            if (IsInJagged(beach, row, col))
            {
                if (beach[row][col] == 'T')
                {
                    tokens++;
                    beach[row][col] = '-';
                }
            }
            else
            {
                return -1;
            }

            return tokens;
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

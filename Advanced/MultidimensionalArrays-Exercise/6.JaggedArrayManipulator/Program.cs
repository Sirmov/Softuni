using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < jagged[row + i].Length; j++)
                        {
                            jagged[row + i][j] *= 2;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < jagged[row + i].Length; j++)
                        {
                            jagged[row + i][j] /= 2;
                        }
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operaion = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);

                if (IsInJagged(jagged, row, col))
                {
                    switch (operaion)
                    {
                        case "Add":
                            jagged[row][col] += value;
                            break;
                        case "Subtract":
                            jagged[row][col] -= value;
                            break;
                    }
                }
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        static bool IsInJagged(double[][] jagged, int row, int col)
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

using System;
using System.Linq;

namespace _6.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];
            
            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (operation == "Add")
                {
                    if (AreCordinatesValid(jagged, row, col))
                    {
                        jagged[row][col] += value;
                    }
                }
                else if (operation == "Subtract")
                {

                    if (AreCordinatesValid(jagged, row, col))
                    {
                        jagged[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (int[] row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool AreCordinatesValid(int[][] jagged, int row, int col)
        {
            if (row < jagged.Length && row >= 0)
            {
                if (col < jagged[row].Length && col >= 0)
                {
                    return true;
                }
            }

            Console.WriteLine("Invalid coordinates");
            return false;
        }
    }
}

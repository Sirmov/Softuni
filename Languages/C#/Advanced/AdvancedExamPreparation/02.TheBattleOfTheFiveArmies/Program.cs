using System;
using System.Linq;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] jagged = new char[rows][];
            int[] armyPossition = new int[2];

            for (int row = 0; row < jagged.Length; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                jagged[row] = line;

                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == 'A')
                    {
                        armyPossition[0] = row;
                        armyPossition[1] = col;
                    }
                }
            }

            while (true)
            {
                string[] turnInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = turnInfo[0];
                int[] orcPossition = turnInfo.Skip(1).Select(int.Parse).ToArray();

                jagged[orcPossition[0]][orcPossition[1]] = 'O';

                int[] estimatedPossition = new int[2];
                switch (direction)
                {
                    case "up":
                        estimatedPossition[0] = armyPossition[0] - 1;
                        estimatedPossition[1] = armyPossition[1];
                        break;
                    case "down":
                        estimatedPossition[0] = armyPossition[0] + 1;
                        estimatedPossition[1] = armyPossition[1];
                        break;
                    case "left":
                        estimatedPossition[0] = armyPossition[0];
                        estimatedPossition[1] = armyPossition[1] - 1;
                        break;
                    case "right":
                        estimatedPossition[0] = armyPossition[0];
                        estimatedPossition[1] = armyPossition[1] + 1;
                        break;
                }

                armyArmor--;

                if (IsInJagged(jagged, estimatedPossition[0], estimatedPossition[1]))
                {
                    if (jagged[estimatedPossition[0]][estimatedPossition[1]] == 'O')
                    {
                        armyArmor -= 2;

                        if (armyArmor < 1)
                        {
                            jagged[estimatedPossition[0]][estimatedPossition[1]] = 'X';
                            jagged[armyPossition[0]][armyPossition[1]] = '-';

                            Console.WriteLine($"The army was defeated at {estimatedPossition[0]};{estimatedPossition[1]}.");
                            PrintJagged(jagged);
                            Environment.Exit(0);
                        }
                    }
                    else if (jagged[estimatedPossition[0]][estimatedPossition[1]] == 'M')
                    {
                        jagged[estimatedPossition[0]][estimatedPossition[1]] = '-';
                        jagged[armyPossition[0]][armyPossition[1]] = '-';
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                        PrintJagged(jagged);
                        Environment.Exit(0);
                    }

                    jagged[estimatedPossition[0]][estimatedPossition[1]] = 'A';
                    jagged[armyPossition[0]][armyPossition[1]] = '-';
                    armyPossition[0] = estimatedPossition[0];
                    armyPossition[1] = estimatedPossition[1];
                }
            }
        }

        private static void PrintJagged(char[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsInJagged(char[][] jagged, int row, int col)
        {
            if (row < 0 || row > jagged.Length - 1 ||
                col < 0 || col > jagged[row].Length - 1)
            {
                return false;
            }

            return true;
        }
    }
}

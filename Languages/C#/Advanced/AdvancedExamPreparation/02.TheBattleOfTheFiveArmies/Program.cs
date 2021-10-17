using System;
using System.Linq;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int[] armyCoordinates = new int[2];

            int rows = int.Parse(Console.ReadLine());
            char[][] map = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                map[i] = row;

                for (int col = 0; col < row.Length; col++)
                {
                    if (row[col] == 'A')
                    {
                        armyCoordinates[0] = i;
                        armyCoordinates[1] = col;
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

                map[orcRow][orcCol] = 'O';

                int estimatedRow = 0;
                int estimatedCol = 0;

                switch (direction)
                {
                    case "up":
                        estimatedRow = armyCoordinates[0] - 1;
                        estimatedCol = armyCoordinates[1];
                        break;
                    case "down":
                        estimatedRow = armyCoordinates[0] + 1;
                        estimatedCol = armyCoordinates[1];
                        break;
                    case "left":
                        estimatedRow = armyCoordinates[0];
                        estimatedCol = armyCoordinates[1] - 1;
                        break;
                    case "right":
                        estimatedRow = armyCoordinates[0];
                        estimatedCol = armyCoordinates[1] + 1;
                        break;
                    default:
                        continue;
                }

                armyArmor--;

                if (IsInJagged(map, estimatedRow, estimatedCol))
                {
                    if (map[estimatedRow][estimatedCol] == 'O')
                    {
                        armyArmor -= 2;
                    }


                    if (map[estimatedRow][estimatedCol] == 'M')
                    {
                        hasWon = true;
                        map[estimatedRow][estimatedCol] = '-';
                        map[armyCoordinates[0]][armyCoordinates[1]] = '-';
                        break;
                    }

                    if (armyArmor <= 0)
                    {
                        hasDied = true;
                        map[estimatedRow][estimatedCol] = 'X';
                        map[armyCoordinates[0]][armyCoordinates[1]] = '-';
                        armyCoordinates[0] = estimatedRow;
                        armyCoordinates[1] = estimatedCol;
                        break;
                    }


                    map[estimatedRow][estimatedCol] = 'A';
                    map[armyCoordinates[0]][armyCoordinates[1]] = '-';
                    armyCoordinates[0] = estimatedRow;
                    armyCoordinates[1] = estimatedCol;
                }
            }

            if (hasDied)
            {
                Console.WriteLine($"The army was defeated at {armyCoordinates[0]};{armyCoordinates[1]}.");
            }
            else if (hasWon)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
            }

            for (int row = 0; row < map.Length; row++)
            {
                Console.WriteLine(new string(map[row]));
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

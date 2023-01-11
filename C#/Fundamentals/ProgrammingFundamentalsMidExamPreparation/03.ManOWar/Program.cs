using System;
using System.Linq;

namespace _03.ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] warship = Console.ReadLine()
                .Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maxHealth = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Retire")
            {
                string[] commandArgs = command.Split();
                string operation = commandArgs[0];

                if (operation == "Fire" && IsValid(int.Parse(commandArgs[1]), warship))
                {
                    warship[int.Parse(commandArgs[1])] -= int.Parse(commandArgs[2]);
                    if (warship[int.Parse(commandArgs[1])] <= 0)
                    {
                        Console.WriteLine("You won! The enemy ship has sunken.");
                        return;
                    }
                }
                else if (operation == "Defend" && IsValid(int.Parse(commandArgs[1]), pirateShip) && IsValid(int.Parse(commandArgs[2]), pirateShip))
                {
                    for (int i = int.Parse(commandArgs[1]); i <= int.Parse(commandArgs[2]); i++)
                    {
                        pirateShip[i] -= int.Parse(commandArgs[3]);
                        if (pirateShip[i] <= 0)
                        {
                            Console.WriteLine("You lost! The pirate ship has sunken.");
                            return;
                        }
                    }
                }
                else if (operation == "Repair" && IsValid(int.Parse(commandArgs[1]), pirateShip))
                {
                    pirateShip[int.Parse(commandArgs[1])] += int.Parse(commandArgs[2]);
                    if (pirateShip[int.Parse(commandArgs[1])] > maxHealth)
                    {
                        pirateShip[int.Parse(commandArgs[1])] = maxHealth;
                    }
                }
                else if (operation == "Status")
                {
                    Console.WriteLine($"{pirateShip.Count(x => x < maxHealth * 0.2)} sections need repair.");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warship.Sum()}");
        }

        static bool IsValid(int index, int[] array)
        {
            return index >= 0 && index < array.Length;
        }
    }
}

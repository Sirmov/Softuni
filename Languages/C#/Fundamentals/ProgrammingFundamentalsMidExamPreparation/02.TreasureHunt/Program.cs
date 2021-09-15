using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("|").ToList();
            string command = Console.ReadLine();
            while (command != "Yohoho!")
            {
                string[] commandArgs = command.Split();
                string operation = commandArgs[0];

                if (operation == "Loot")
                {
                    for (int i = 1; i < commandArgs.Length; i++)
                    {
                        if (!chest.Contains(commandArgs[i]))
                        {
                            chest.Insert(0, commandArgs[i]);
                        }
                    }
                }
                else if (operation == "Drop")
                {
                    int index = int.Parse(commandArgs[1]);
                    if (index >= 0 && index < chest.Count)
                    {
                        string temp = chest[index];
                        chest.RemoveAt(index);
                        chest.Add(temp);
                    }
                }
                else if (operation == "Steal")
                {
                    int count = int.Parse(commandArgs[1]);
                    if (count > chest.Count)
                    {
                        count = chest.Count;
                    }

                    List<string> removed = new List<string>();

                    for (int i = 0; i < count; i++)
                    {
                        removed.Add(chest[chest.Count - 1]);
                        chest.RemoveAt(chest.Count - 1);
                    }

                    removed.Reverse();
                    Console.WriteLine(string.Join(", ", removed));
                }

                command = Console.ReadLine();
            }

            if (chest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
                Environment.Exit(0);
            }

            double gain = 0;

            foreach (string loot in chest)
            {
                gain += loot.Length;
            }

            gain /= chest.Count;
            Console.WriteLine($"Average treasure gain: {gain:F2} pirate credits.");
        }
    }
}

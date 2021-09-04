using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invetory = Console.ReadLine().Split(", ").ToList();
            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] commandArgs = command.Split(" - ");

                if (commandArgs[0] == "Collect")
                {
                    if (!invetory.Contains(commandArgs[1]))
                    {
                        invetory.Add(commandArgs[1]);
                    }
                }
                else if (commandArgs[0] == "Drop")
                {
                    if (invetory.Contains(commandArgs[1]))
                    {
                        invetory.Remove(commandArgs[1]);
                    }
                }
                else if (commandArgs[0] == "Combine Items")
                {
                    string[] items = commandArgs[1].Split(":");
                    if (invetory.Contains(items[0]))
                    {
                        invetory.Insert(invetory.FindIndex(x => x == items[0]) + 1, items[1]);
                    }
                }
                else if (commandArgs[0] == "Renew")
                {
                    if (invetory.Contains(commandArgs[1]))
                    {
                        string temp = commandArgs[1];
                        invetory.Remove(temp);
                        invetory.Add(temp);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", invetory));
        }
    }
}

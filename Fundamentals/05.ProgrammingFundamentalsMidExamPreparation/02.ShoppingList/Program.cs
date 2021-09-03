using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "Go Shopping!")
            {
                string[] commandArgs = command.Split();
                string operation = commandArgs[0];
                if (operation == "Urgent")
                {
                    if (!groceries.Contains(commandArgs[1]))
                    {
                        groceries.Insert(0, commandArgs[1]);
                    }
                }
                else if (operation == "Unnecessary")
                {
                    groceries.Remove(commandArgs[1]);
                }
                else if (operation == "Correct")
                {
                    if (groceries.Contains(commandArgs[1]))
                    {
                        groceries[groceries.FindIndex(x => x == commandArgs[1])] = commandArgs[2];
                    }
                }
                else if (operation == "Rearrange")
                {
                    if (groceries.Contains(commandArgs[1]))
                    {
                        groceries.Add(commandArgs[1]);
                        groceries.Remove(commandArgs[1]);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}

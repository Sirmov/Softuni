using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArgs = command.Split(" - ");
                string operation = commandArgs[0];

                if (operation == "Add" && !phones.Contains(commandArgs[1]))
                {
                    phones.Add(commandArgs[1]);
                }
                else if (operation == "Remove" && phones.Contains(commandArgs[1]))
                {
                    phones.Remove(commandArgs[1]);
                }
                else if (operation == "Bonus phone")
                {
                    string oldPhone = commandArgs[1].Split(":")[0];
                    string newPhone = commandArgs[1].Split(":")[1];

                    if (phones.Contains(oldPhone))
                    {
                        phones.Insert(phones.IndexOf(oldPhone) + 1, newPhone);
                    }
                }
                else if (operation == "Last" && phones.Contains(commandArgs[1]))
                {
                    phones.Remove(commandArgs[1]);
                    phones.Add(commandArgs[1]);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}

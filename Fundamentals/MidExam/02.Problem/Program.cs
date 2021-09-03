using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> weapon = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = commandArgs[0];

                if (operation == "Add" && IsValid(int.Parse(commandArgs[2]), weapon))
                {
                    weapon.Insert(int.Parse(commandArgs[2]), commandArgs[1]);
                }
                else if (operation == "Remove" && IsValid(int.Parse(commandArgs[1]), weapon))
                {
                    weapon.RemoveAt(int.Parse(commandArgs[1]));
                }
                else if (operation == "Check")
                {
                    if (commandArgs[1] == "Even")
                    {
                        List<string> result = new List<string>();
                        for (int i = 0; i < weapon.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                result.Add(weapon[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", result));
                    }
                    else if (commandArgs[1] == "Odd")
                    {
                        List<string> result = new List<string>();
                        for (int i = 0; i < weapon.Count; i++)
                        {
                            if (i % 2 != 0)
                            {
                                result.Add(weapon[i]);
                            }
                        }

                        Console.WriteLine(string.Join(" ", result));
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You crafted {string.Join("", weapon)}!");
        }

        static bool IsValid(int index, List<string> list)
        {
            return index >= 0 && index < list.Count;
        }
    }
}

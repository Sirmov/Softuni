using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();
                string operation = commandArgs[0];
                int index = int.Parse(commandArgs[1]);

                if (operation == "Shoot")
                {
                    if (index < 0 || index >= targets.Count)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        targets[index] -= int.Parse(commandArgs[2]);
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (operation == "Add")
                {
                    if (index < 0 || index >= targets.Count)
                    {
                        Console.WriteLine("Invalid placement!");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        targets.Insert(index, int.Parse(commandArgs[2]));
                    }
                }
                else if (operation == "Strike")
                {
                    int range = int.Parse(commandArgs[2]);
                    if (index - range < 0 || index + range >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        targets.RemoveRange(index - range, range * 2 + 1);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }
    }
}

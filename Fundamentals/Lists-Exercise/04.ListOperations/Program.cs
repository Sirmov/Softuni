using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArgs = command.Split();

                if (commandArgs[0] == "Add")
                {
                    numbers.Add(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "Insert")
                {
                    if (int.Parse(commandArgs[2]) < 0 || int.Parse(commandArgs[2]) >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                    }
                }
                else if (commandArgs[0] == "Remove")
                {
                    if (int.Parse(commandArgs[1]) < 0 || int.Parse(commandArgs[1]) >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(commandArgs[1]));
                    }
                }
                else if (commandArgs[0] == "Shift")
                {
                    if (commandArgs[1] == "left")
                    {
                        for (int i = 0; i < int.Parse(commandArgs[2]); i++)
                        {
                            int temp = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(temp);
                        }
                    }
                    else if (commandArgs[1] == "right")
                    {
                        for (int i = 0; i < int.Parse(commandArgs[2]); i++)
                        {
                            int temp = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, temp);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

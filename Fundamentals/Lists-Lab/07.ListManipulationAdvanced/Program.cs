using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            bool isChanged = false;

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArgs = command.Split();
                if (commandArgs[0] == "Add")
                {
                    numbers.Add(int.Parse(commandArgs[1]));
                    isChanged = true;
                }
                else if (commandArgs[0] == "Remove")
                {
                    numbers.Remove(int.Parse(commandArgs[1]));
                    isChanged = true;
                }
                else if (commandArgs[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(commandArgs[1]));
                    isChanged = true;
                }
                else if (commandArgs[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                    isChanged = true;
                }
                else if (commandArgs[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(commandArgs[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (commandArgs[0] == "PrintEven")
                {
                    PrintEven(numbers);
                }
                else if (commandArgs[0] == "PrintOdd")
                {
                    PrintOdd(numbers);
                }
                else if (commandArgs[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (commandArgs[0] == "Filter")
                {
                    Filter(numbers, commandArgs[1], int.Parse(commandArgs[2]));
                }

                command = Console.ReadLine();
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static void Filter(List<int> numbers, string condition, int number)
        {
            if (condition == "<")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x < number)));
            }
            else if (condition == ">")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x > number)));
            }
            else if (condition == ">=")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x >= number)));
            }
            else if (condition == "<=")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x <= number)));
            }
        }

        private static void PrintOdd(List<int> numbers)
        {
            Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0)));
        }

        private static void PrintEven(List<int> numbers)
        {
            Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
        }
    }
}
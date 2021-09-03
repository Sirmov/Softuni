using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace _02.ChangeList
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
            while (command != "end")
            {
                string[] commandArgs = command.Split();

                if (commandArgs[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

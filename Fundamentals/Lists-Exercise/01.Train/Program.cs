using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArgs = command.Split();

                if (commandArgs[0] == "Add")
                {
                    wagons.Add(int.Parse(commandArgs[1]));
                }
                else
                {
                    int passengers = int.Parse(commandArgs[0]);
                    FitPassengers(wagons, passengers, maxCapacity);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', wagons));
        }

        static void FitPassengers(List<int> wagons, int passengers, int maxCapacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + passengers <= maxCapacity)
                {
                    wagons[i] = wagons[i] + passengers;
                    break;
                }
            }
        }
    }
}

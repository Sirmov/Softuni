using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                if (commandArgs[2] == "going!")
                {
                    if (guests.Contains(commandArgs[0]))
                    {
                        Console.WriteLine($"{commandArgs[0]} is already in the list!");
                        continue;
                    }
                    else
                    {
                        guests.Add(commandArgs[0]);
                        continue;
                    }
                }
                else if (commandArgs[2] == "not")
                {
                    if (!guests.Contains(commandArgs[0]))
                    {
                        Console.WriteLine($"{commandArgs[0]} is not in the list!");
                        continue;
                    }
                    else
                    {
                        guests.Remove(commandArgs[0]);
                        continue;
                    }
                }
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}

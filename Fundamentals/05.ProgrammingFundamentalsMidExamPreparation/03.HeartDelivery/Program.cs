using System;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int cupid = 0;
            int valentine = 0;

            string command = Console.ReadLine();
            while (command != "Love!")
            {
                string[] commandArgs = command.Split();
                int lenght = int.Parse(commandArgs[1]);

                if (cupid + lenght >= neighborhood.Length)
                {
                    cupid = 0;
                    if (neighborhood[cupid] == 0)
                    {
                        Console.WriteLine($"Place {cupid} already had Valentine's day.");
                    }
                    else
                    {
                        neighborhood[cupid] -= 2;
                        if (neighborhood[cupid] == 0)
                        {
                            Console.WriteLine($"Place {cupid} has Valentine's day.");
                            valentine++;
                        }
                    }
                }
                else
                {
                    cupid += lenght;
                    if (neighborhood[cupid] == 0)
                    {
                        Console.WriteLine($"Place {cupid} already had Valentine's day.");
                    }
                    else
                    {
                        neighborhood[cupid] -= 2;
                        if (neighborhood[cupid] == 0)
                        {
                            Console.WriteLine($"Place {cupid} has Valentine's day.");
                            valentine++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {cupid}.");
            if (valentine == neighborhood.Length)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {neighborhood.Length - valentine} places.");
            }
        }
    }
}

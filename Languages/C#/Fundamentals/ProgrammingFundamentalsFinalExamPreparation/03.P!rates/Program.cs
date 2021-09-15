using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cities = new Dictionary<string, City>();

            string city = Console.ReadLine();
            while (city != "Sail")
            {
                string[] arguments = city.Split("||");
                string name = arguments[0];
                int population = int.Parse(arguments[1]);
                int gold = int.Parse(arguments[2]);

                if (!cities.ContainsKey(name))
                {
                    cities.Add(name, new City(population, gold));
                }
                else
                {
                    cities[name].Population += population;
                    cities[name].Gold += gold;
                }

                city = Console.ReadLine();
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArgs = command.Split("=>");
                string operation = commandArgs[0];
                string name = commandArgs[1];

                if (operation == "Plunder")
                {
                    int people = int.Parse(commandArgs[2]);
                    int gold = int.Parse(commandArgs[3]);
                    Console.WriteLine($"{name} plundered! {gold} gold stolen, {people} citizens killed.");

                    cities[name].Population -= people;
                    cities[name].Gold -= gold;

                    if (cities[name].Gold <= 0 || cities[name].Population <= 0)
                    {
                        cities.Remove(name);
                        Console.WriteLine($"{name} has been wiped off the map!");
                    }
                }
                else if (operation == "Prosper")
                {
                    int gold = int.Parse(commandArgs[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[name].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {cities[name].Gold} gold.");
                    }
                }

                command = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var item in cities.OrderByDescending(x => x.Value.Gold).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value.Population} citizens, Gold: {item.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    class City
    {
        public int Population { get; set; }
        public int Gold { get; set; }

        public City(int population, int gold)
        {
            Population = population;
            Gold = gold;
        }
    }
}

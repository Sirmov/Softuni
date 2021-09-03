using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] plant = Console.ReadLine().Split("<->");
                string name = plant[0];
                int rarity = int.Parse(plant[1]);

                if (!plants.ContainsKey(name))
                {
                    plants.Add(name, new Plant(rarity));
                }
                else
                {
                    plants[name].Rarity = rarity;
                }
            }

            string command = Console.ReadLine();
            while (command != "Exhibition")
            {
                string[] commandArgs = command.Split(" ");
                string operation = commandArgs[0];

                if (operation == "Rate:")
                {
                    string name = commandArgs[1];
                    double rating = double.Parse(commandArgs[3]);

                    if (plants.ContainsKey(name))
                    {
                        plants[name].Ratings.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (operation == "Update:")
                {
                    string name = commandArgs[1];
                    int rarity = int.Parse(commandArgs[3]);

                    if (plants.ContainsKey(name))
                    {
                        plants[name].Rarity = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (operation == "Reset:")
                {
                    string name = commandArgs[1];

                    if (plants.ContainsKey(name))
                    {
                        plants[name].Ratings = new List<double>();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants.OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(x => x.Value.AverageRating()))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {plant.Value.AverageRating():F2}");
            }
        }
    }

    class Plant
    {
        public int Rarity { get; set; }
        public List<double> Ratings { get; set; }

        public Plant(int rarity)
        {
            Rarity = rarity;
            Ratings = new List<double>();
        }

        public double AverageRating()
        {
            if (Ratings.Count > 0)
            {
                return Ratings.Average();
            }
            else
            {
                return 0.00;
            }
        }
    }
}
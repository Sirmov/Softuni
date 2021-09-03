using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>
            {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 }
            };
            Dictionary<string, int> junk = new Dictionary<string, int>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                bool isEnough = false;
                string legendary = "";

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string item = input[i + 1].ToLower();

                    if (materials.ContainsKey(item))
                    {
                        materials[item] += quantity;
                    }
                    else
                    {
                        if (!junk.ContainsKey(item))
                        {
                            junk.Add(item, 0);
                        }

                        junk[item] += quantity;
                    }

                    foreach (var material in materials)
                    {
                        if (material.Value >= 250)
                        {
                            isEnough = true;
                            legendary = material.Key;
                        }
                    }

                    if (isEnough)
                    {
                        break;
                    }
                }

                if (isEnough)
                {
                    Craft(legendary);
                    materials[legendary] -= 250;
                    break;
                }
            }

            materials = materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            foreach (var item in materials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            junk = junk.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        static void Craft(string item)
        {
            if (item == "shards")
            {
                Console.WriteLine($"Shadowmourne obtained!");
            }
            else if (item == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (item == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }
        }
    }
}

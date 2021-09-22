using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int clothesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < clothesCount; i++)
            {
                string[] line = Console.ReadLine().Split(" -> ");
                string color = line[0];
                List<string> clothes = line[1].Split(",").ToList();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color].Add(cloth, 0);
                    }

                    wardrobe[color][cloth]++;
                }
            }

            string[] clothing = Console.ReadLine().Split();

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in wardrobe[color.Key])
                {
                    if (color.Key == clothing[0] && cloth.Key == clothing[1])
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}

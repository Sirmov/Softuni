using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> ores = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "stop")
            {
                string ore = input;
                int quantity = int.Parse(Console.ReadLine());

                if (!ores.ContainsKey(ore))
                {
                    ores.Add(ore, 0);
                }

                ores[ore] += quantity;

                input = Console.ReadLine();
            }

            foreach (var ore in ores)
            {
                Console.WriteLine($"{ore.Key} -> {ore.Value}");
            }
        }
    }
}

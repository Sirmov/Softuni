using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            List<int> plates = new List<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            for (int i = 1; i <= waves; i++)
            {
                Stack<int> orcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    int orc = orcs.Peek();
                    int plate = plates[0];

                    if (orc > plate)
                    {
                        orc -= plate;
                        orcs.Pop();
                        orcs.Push(orc);

                        plates.RemoveAt(0);
                    }
                    else if (plate > orc)
                    {
                        plate -= orc;
                        plates[0] = plate;

                        orcs.Pop();
                    }
                    else
                    {
                        orcs.Pop();
                        plates.RemoveAt(0);
                    }
                }

                if (plates.Count == 0)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                    if (orcs.Count > 0)
                    {
                        Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                    }

                    return;
                }
            }

            Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
        }
    }
}

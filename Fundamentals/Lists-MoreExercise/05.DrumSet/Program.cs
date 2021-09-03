using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> originalDrumSet = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> drumSet = originalDrumSet.ToList();

            string input = Console.ReadLine();
            while (input != "Hit it again, Gabsy!")
            {
                int power = int.Parse(input);

                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= power;
                }

                for (int i = 0; i < drumSet.Count; i++)
                {
                    if (drumSet[i] < 1)
                    {
                        int cost = originalDrumSet[i] * 3;
                        if (savings >= cost)
                        {
                            savings -= cost;
                            drumSet[i] = originalDrumSet[i];
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            originalDrumSet.RemoveAt(i);
                            i--;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}

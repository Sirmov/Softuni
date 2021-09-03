using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();
            int shot = 0;

            while (command != "End")
            {
                int index = int.Parse(command);

                if (!isValid(targets, index))
                {
                    command = Console.ReadLine();
                    continue;
                }

                int currTarget = targets[index];

                if (targets[index] != -1)
                {
                    targets[index] = -1;
                    shot++;
                }

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] != -1)
                    {
                        if (targets[i] > currTarget)
                        {
                            targets[i] -= currTarget;
                        }
                        else
                        {
                            targets[i] += currTarget;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shot} -> {string.Join(" ", targets)}");
        }

        static bool isValid(int[] array, int index)
        {
            return index >= 0 && index < array.Length;
        }
    }
}

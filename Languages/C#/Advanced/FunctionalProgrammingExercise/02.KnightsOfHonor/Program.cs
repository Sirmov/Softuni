using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string> Print = s => Console.WriteLine($"Sir {s}");

            foreach (var name in names)
            {
                Print(name);
            }
        }
    }
}

using System;
using System.Linq;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int i = 0;

            while (i < lift.Length && people > 0)
            {
                if (lift[i] < 4)
                {
                    lift[i] += 1;
                    people--;
                }
                else
                {
                    i++;
                }
            }

            if (lift.Count(x => x < 4) > 0)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else if (people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else
            {
                Console.WriteLine(string.Join(" ", lift));
            }
        }
    }
}

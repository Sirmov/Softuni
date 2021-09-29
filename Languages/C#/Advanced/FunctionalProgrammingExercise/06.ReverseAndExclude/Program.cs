using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            int devisor = int.Parse(Console.ReadLine());

            Predicate<int> isDevisible = n => n % devisor == 0;
            List<int> filtered = new List<int>();

            foreach (var num in numbers)
            {
                if (!isDevisible(num))
                {
                    filtered.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", filtered));
        }
    }
}

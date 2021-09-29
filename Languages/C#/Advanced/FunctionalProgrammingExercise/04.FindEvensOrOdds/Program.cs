using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Enumerable.Range(range[0], range[1] - range[0] + 1).ToArray();
            string condition = Console.ReadLine();

            Predicate<int> predicate = n => true;
            if (condition == "odd")
            {
                predicate = n => n % 2 == 1 || n % 2 == -1;
            }
            else if (condition == "even")
            {
                predicate = n => n % 2 == 0;
            }

            List<int> filtered = new List<int>();

            foreach (var num in numbers)
            {
                if (predicate(num))
                {
                    filtered.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", filtered));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] numbers = Enumerable.Range(1, range).ToArray();
            int[] deviders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<Predicate<int>> predicates = new HashSet<Predicate<int>>();
            foreach (var devider in deviders)
            {
                predicates.Add((x) => x % devider == 0);
            }

            List<int> filtered = new List<int>();

            foreach (var num in numbers)
            {
                bool isValid = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(num))
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    filtered.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", filtered));
        }
    }
}

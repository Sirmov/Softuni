using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            SortedDictionary<int, int> occurrences = new SortedDictionary<int, int>();

            foreach (var num in numbers)
            {
                if (!occurrences.ContainsKey(num))
                {
                    occurrences.Add(num, 0);
                }

                occurrences[num]++;
            }

            foreach (var occurrence in occurrences)
            {
                Console.WriteLine($"{occurrence.Key} -> {occurrence.Value}");
            }
        }
    }
}

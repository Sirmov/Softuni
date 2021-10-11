using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> occurrences = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!occurrences.ContainsKey(numbers[i]))
                {
                    occurrences.Add(numbers[i], 0);
                }

                occurrences[numbers[i]]++;
            }

            foreach (var num in occurrences)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}

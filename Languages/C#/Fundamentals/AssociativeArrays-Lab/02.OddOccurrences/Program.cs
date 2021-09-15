using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> occurrences = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string lower = word.ToLower();
                if (!occurrences.ContainsKey(lower))
                {
                    occurrences.Add(lower, 0);
                }

                occurrences[lower]++;
            }

            occurrences = occurrences.Where(x => x.Value % 2 == 1).ToDictionary(x => x.Key, x => x.Value);

            foreach (var key in occurrences)
            {
                Console.Write($"{key.Key} ");
            }
        }
    }
}

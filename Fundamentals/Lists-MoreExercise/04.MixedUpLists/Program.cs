using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> second = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> mixed = new List<int>();

            int[] constraints = new int[2];

            if (first.Count > second.Count)
            {
                constraints[0] = first[first.Count - 1];
                constraints[1] = first[first.Count - 2];
                first.RemoveRange(first.Count - 2, 2);
            }
            else
            {
                constraints[0] = second[0];
                constraints[1] = second[1];
                second.RemoveRange(0, 2);
            }

            Array.Sort(constraints);

            for (int i = 0; i < first.Count; i++)
            {
                mixed.Add(first[i]);
                mixed.Add(second[second.Count - 1 - i]);
            }
            
            mixed.RemoveAll(x => x <= constraints[0] || x >= constraints[1]);
            mixed.Sort();
            Console.WriteLine(string.Join(" ", mixed));
        }
    }
}

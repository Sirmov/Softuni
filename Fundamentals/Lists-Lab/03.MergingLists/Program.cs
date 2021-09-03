using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> result = new List<int>(Math.Max(first.Length, second.Length) * 2);

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                result.Add(first[i]);
                result.Add(second[i]);
            }

            if (first.Length > second.Length)
            {
                int count = first.Length - second.Length;
                for (int i = 0; i < count; i++)
                {
                    result.Add(first[i + second.Length]);
                }
            }
            else if (second.Length > first.Length)
            {
                int count = second.Length - first.Length;
                for (int i = 0; i < count; i++)
                {
                    result.Add(second[i + first.Length]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

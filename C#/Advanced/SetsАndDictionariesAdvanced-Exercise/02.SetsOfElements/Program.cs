using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Dictionary<int, int> firstSet = new Dictionary<int, int>(sizes[0]);
            HashSet<int> secondSet = new HashSet<int>(sizes[1]);

            for (int i = 0; i < sizes[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!firstSet.ContainsKey(num))
                {
                    firstSet.Add(num, 0);
                }

                firstSet[num]++;
            }

            for (int i = 0; i < sizes[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var num in firstSet)
            {
                if (secondSet.Contains(num.Key))
                {
                    Console.Write(num.Key + " ");
                }
            }
        }
    }
}

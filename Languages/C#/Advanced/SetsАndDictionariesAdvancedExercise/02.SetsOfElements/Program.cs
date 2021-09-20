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
            Dictionary<string, int> firstSet = new Dictionary<string, int>(sizes[0]);
            HashSet<string> secondSet = new HashSet<string>(sizes[1]);

            for (int i = 0; i < sizes[0]; i++)
            {
                string str = Console.ReadLine();

                if (!firstSet.ContainsKey(str))
                {
                    firstSet.Add(str, 0);
                }

                firstSet[str]++;
            }
            for (int i = 0; i < sizes[1]; i++)
            {
                secondSet.Add(Console.ReadLine());
            }


            foreach (var str in firstSet)
            {
                if (secondSet.Contains(str.Key) && str.Value == 1)
                {
                    Console.Write(str.Key + " ");
                }
            }
        }
    }
}

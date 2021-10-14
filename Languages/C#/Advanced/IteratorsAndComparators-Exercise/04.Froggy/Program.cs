using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Lake lake = new Lake(stones);
            List<int> path = new List<int>(stones.Length);

            foreach (var stone in lake)
            {
                path.Add(stone);
            }

            Console.WriteLine(string.Join(", ", path));
        }
    }
}

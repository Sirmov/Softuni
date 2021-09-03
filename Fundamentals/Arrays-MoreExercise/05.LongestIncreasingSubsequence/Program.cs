using System;
using System.Linq;

namespace _05.LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] LIS;
            int[] len = new int[input.Length];
            int[] prev = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {

            }
        }
    }
}

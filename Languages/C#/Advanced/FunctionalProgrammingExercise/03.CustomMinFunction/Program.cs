using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> GetSmallest = a => a.Min();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(GetSmallest(input));
        }
    }
}

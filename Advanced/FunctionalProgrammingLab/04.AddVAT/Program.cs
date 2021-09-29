using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = Console.ReadLine().Split(", ").Select(double.Parse);
            var pricesWithVAT = prices.Select(p => p * 1.2);
            foreach (var price in pricesWithVAT)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}

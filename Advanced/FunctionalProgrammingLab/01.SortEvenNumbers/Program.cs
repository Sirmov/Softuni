using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine().Split(", ").Select(int.Parse);
            var sortedEvenNumbers = inputNumbers.Where(num => num % 2 == 0).OrderBy(num => num);
            Console.WriteLine(string.Join(", ", sortedEvenNumbers));
        }
    }
}

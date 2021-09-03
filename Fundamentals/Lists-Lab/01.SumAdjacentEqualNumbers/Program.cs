using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            
            EqualNumbers(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void EqualNumbers(List<double> numbers)
        {
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    numbers[i] = numbers[i] * 2;
                    numbers.RemoveAt(i - 1);
                    EqualNumbers(numbers);
                }
            }
        }
    }
}

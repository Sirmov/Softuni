using System;
using System.Linq;

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int iterations = int.Parse(Console.ReadLine());

            for (int i = 0; i < iterations; i++)
            {
                int firstElement = input[0];

                for (int j = 0; j < input.Length - 1; j++)
                {
                    input[j] = input[j + 1];
                }

                input[input.Length - 1] = firstElement;
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}

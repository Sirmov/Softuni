using System;
using System.Linq;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                
                long[] numbers = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                if (numbers[0] > numbers[1])
                {
                    Console.WriteLine(GetSum(numbers[0]));
                }
                else
                {
                    Console.WriteLine(GetSum(numbers[1]));
                }
            }
        }

        static long GetSum(long num)
        {
            long sum = 0;

            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return Math.Abs(sum);
        }
    }
}

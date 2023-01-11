using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<char> str = Console.ReadLine().ToCharArray().ToList();

            for (int i = 0; i < numbers.Length; i++)
            {
                int sum = 0;

                while (numbers[i] > 0)
                {
                    sum += numbers[i] % 10;
                    numbers[i] /= 10;
                }

                numbers[i] = sum;
            }

            string result = string.Empty;

            for (int i = 0; i < numbers.Length; i++)
            {
                int index = numbers[i];

                if (index >= str.Count)
                {
                    index -= str.Count;
                }

                result += str[index];
                str.RemoveAt(index);
            }

            Console.WriteLine(result);
        }
    }
}
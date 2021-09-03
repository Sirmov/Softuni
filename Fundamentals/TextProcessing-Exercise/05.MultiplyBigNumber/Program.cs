using System;
using System.Linq;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
            int multiply = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            int reminder = 0;

            if (multiply == 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int digit = ((input[i] * multiply) + reminder) % 10;
                reminder = ((input[i] * multiply) + reminder) / 10;

                result.Insert(0, digit);
            }

            if (reminder > 0)
            {
                result.Insert(0, reminder);
            }

            Console.WriteLine(result);
        }
    }
}

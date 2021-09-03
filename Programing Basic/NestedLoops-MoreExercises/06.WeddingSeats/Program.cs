using System;
using System.Linq;

namespace _06.WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            int[] output = new int[input.Length];
            for (int i = 0; i < output.Length; i++)
            {
                if (input[i] == -0)
                {
                    output[i] = 0;
                }
                else
                {
                output[i] = (int)Math.Round(input[i], MidpointRounding.AwayFromZero);
                }
            }

            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine($"{input[i]} => {output[i]}");
            }
        }
    }
}

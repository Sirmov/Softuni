using System;

namespace _02.PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                int temp = numbers[numbers.Length - 1 - i];
                numbers[numbers.Length - 1 - i] = numbers[i];
                numbers[i] = temp;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

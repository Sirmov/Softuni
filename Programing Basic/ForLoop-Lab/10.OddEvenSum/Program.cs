using System;

namespace _10.OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSum = 0;
            int current;
            for (int i = 1; i <= N; i++)
            {
                current = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += current;
                }
                else
                {
                    oddSum += current;
                }
            }
            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(evenSum - oddSum)}");
            }
        }
    }
}

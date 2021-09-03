using System;

namespace _08.NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int min;
            int max;
            if (N == 0)
            {
                min = 0;
            }
            else
            {
                min = 2147483647;
            }
            if (N == 0)
            {
                max = 0;
            }
            else
            {
                max = -2147483647;
            }
            int current;
            for (int i = 0; i < N; i++)
            {
                current = int.Parse(Console.ReadLine());
                max = Math.Max(current, max);
                min = Math.Min(current, min);
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}

using System;

namespace _02.HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            int currentNum = 0;
            for (int i = 0; i < num; i++)
            {
                currentNum = int.Parse(Console.ReadLine());
                if (currentNum > max)
                {
                    max = currentNum;
                }
                sum += currentNum;
            }
            sum -= max;
            if (sum == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(max - sum)}");
            }
        }
    }
}

using System;

namespace _08.EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxDiff = 0;
            int diff = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());
                int currentSum = firstNum + secondNum;
                int currentDiff = Math.Abs(currentSum - sum);
                if (n > 1)
                {
                    maxDiff = Math.Max(currentDiff, diff);
                }
                sum = firstNum + secondNum;
                diff = Math.Abs(currentSum - sum);
            }
            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value={sum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}

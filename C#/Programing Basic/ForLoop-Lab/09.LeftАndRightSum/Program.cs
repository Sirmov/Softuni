using System;

namespace _09.LeftАndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            int current;
            
            for (int i = 1; i <= N; i++)
            {
                current = int.Parse(Console.ReadLine());
                leftSum += current;
            }
            for (int i = 1; i <= N; i++)
            {
                current = int.Parse(Console.ReadLine());
                rightSum += current;
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else if (leftSum > rightSum)
            {
                Console.WriteLine($"No, diff = {leftSum - rightSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {rightSum - leftSum}");
            }
        }
    }
}

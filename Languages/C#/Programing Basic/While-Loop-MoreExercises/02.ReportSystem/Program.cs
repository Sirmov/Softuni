using System;

namespace _02.ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            int collected = 0;
            int CSCount = 0;
            int CSSum = 0;
            int CCCount = 0;
            int CCSum = 0;
            int days = 1;
            while(collected < target)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine("Failed to collect required money for charity.");
                    return;
                }
                if (days % 2 != 0)
                {
                    if (int.Parse(input) > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        collected += int.Parse(input);
                        Console.WriteLine("Product sold!");
                        CSCount++;
                        CSSum += int.Parse(input);
                    }
                }
                else
                {
                    if (int.Parse(input) < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        collected += int.Parse(input);
                        Console.WriteLine("Product sold!");
                        CCCount++;
                        CCSum += int.Parse(input);
                    }
                }
                days++;
            }
            Console.WriteLine($"Average CS: {CSSum * 1.00 / CSCount:F2}");
            Console.WriteLine($"Average CC: {CCSum * 1.00 / CCCount:F2}");
        }
    }
}

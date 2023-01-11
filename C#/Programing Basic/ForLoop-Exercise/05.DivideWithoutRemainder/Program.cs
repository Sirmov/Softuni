using System;

namespace _05.DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = int.Parse(Console.ReadLine());
            double p1Num = 0;
            double p2Num = 0;
            double p3Num = 0;
            for (int i = 0; i < num; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());
                if (currentNum % 2 == 0)
                {
                    p1Num++;
                }
                if (currentNum % 3 == 0)
                {
                    p2Num++;
                }
                if (currentNum % 4 == 0)
                {
                    p3Num++;
                }
            }
            Console.WriteLine($"{p1Num / num * 100:F2}%");
            Console.WriteLine($"{p2Num / num * 100:F2}%");
            Console.WriteLine($"{p3Num / num * 100:F2}%");
        }
    }
}

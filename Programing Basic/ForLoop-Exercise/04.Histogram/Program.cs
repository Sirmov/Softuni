using System;

namespace _04.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = int.Parse(Console.ReadLine());
            double p1Num = 0;
            double p2Num = 0;
            double p3Num = 0;
            double p4Num = 0;
            double p5Num = 0;
            for (int i = 0; i < num; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());
                if (currentNum < 200)
                {
                    p1Num++;
                }
                else if (currentNum >= 200 && currentNum < 400)
                {
                    p2Num++;
                }
                else if (currentNum >= 400 && currentNum < 600)
                {
                    p3Num++;
                }
                else if (currentNum >= 600 && currentNum < 800)
                {
                    p4Num++;
                }
                else
                {
                    p5Num++;
                }
            }
            Console.WriteLine($"{p1Num / num * 100:F2}%");
            Console.WriteLine($"{p2Num / num * 100:F2}%");
            Console.WriteLine($"{p3Num / num * 100:F2}%");
            Console.WriteLine($"{p4Num / num * 100:F2}%");
            Console.WriteLine($"{p5Num / num * 100:F2}%");
        }
    }
}

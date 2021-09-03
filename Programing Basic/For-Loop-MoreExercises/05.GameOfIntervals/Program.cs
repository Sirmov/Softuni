using System;

namespace _05.GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int turns = int.Parse(Console.ReadLine());
            double result = 0.00;
            int currentNumber;
            double from0To9 = 0;
            double from10To19 = 0;
            double from20To29 = 0;
            double from30To39 = 0;
            double from40To50 = 0;
            double invalid = 0;
            for (int i = 0; i < turns; i++)
            {
                currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber >= 0 && currentNumber <= 9)
                {
                    from0To9++;
                    result += currentNumber * 0.20;
                }
                else if (currentNumber >= 10 && currentNumber <= 19)
                {
                    from10To19++;
                    result += currentNumber * 0.30;
                }
                else if (currentNumber >= 20 && currentNumber <= 29)
                {
                    from20To29++;
                    result += currentNumber * 0.40;
                }
                else if (currentNumber >= 30 && currentNumber <= 39)
                {
                    from30To39++;
                    result += 50;
                }
                else if (currentNumber >= 40 && currentNumber <= 50)
                {
                    from40To50++;
                    result += 100;
                }
                else
                {
                    invalid++;
                    result /= 2;
                }
            }
            Console.WriteLine($"{result:F2}");
            Console.WriteLine($"From 0 to 9: {from0To9/turns * 100:F2}%");
            Console.WriteLine($"From 10 to 19: {from10To19/turns * 100:F2}%");
            Console.WriteLine($"From 20 to 29: {from20To29/turns * 100:F2}%");
            Console.WriteLine($"From 30 to 39: {from30To39/turns * 100:F2}%");
            Console.WriteLine($"From 40 to 50: {from40To50/turns * 100:F2}%");
            Console.WriteLine($"Invalid numbers: {invalid/turns * 100:F2}%");
        }
    }
}

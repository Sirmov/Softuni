using System;

namespace _06.GoldMine
{
    class Program
    {
        static void Main(string[] args)
        {
            int locations = int.Parse(Console.ReadLine());
            for (int i = 1; i <= locations; i++)
            {
                double target = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                double totalGoldYield = 0;
                for (int j = 1; j <= days; j++)
                {
                    double goldYield = double.Parse(Console.ReadLine());
                    totalGoldYield += goldYield;
                }
                totalGoldYield /= days;
                if (totalGoldYield >= target)
                {
                    Console.WriteLine($"Good job! Average gold per day: {totalGoldYield:F2}.");
                }
                else
                {
                    Console.WriteLine($"You need {target - totalGoldYield:F2} gold.");
                }
            }
        }
    }
}

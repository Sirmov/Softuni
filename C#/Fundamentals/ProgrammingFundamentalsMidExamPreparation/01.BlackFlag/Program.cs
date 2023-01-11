using System;

namespace _01.BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int plunder = int.Parse(Console.ReadLine());
            double goal = double.Parse(Console.ReadLine());
            double money = 0;

            for (int i = 1; i <= days; i++)
            {
                money += plunder;
                if (i % 3 == 0)
                {
                    money += plunder * 0.5;
                }

                if (i % 5 == 0)
                {
                    money -= money * 0.3;
                }
            }

            if (money >= goal)
            {
                Console.WriteLine($"Ahoy! {money:F2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {money/goal * 100:F2}% of the plunder.");
            }
        }
    }
}

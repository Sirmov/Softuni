using System;

namespace _01.BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int yearTarget = int.Parse(Console.ReadLine());
            int age = 18;
            int year = 1800;
            double costs = 0;
            for (int i = year; i <= yearTarget; i++)
            {
                if (i % 2 == 0)
                {
                    costs += 12000;
                }
                else
                {
                    costs += 12000 + 50 * age;
                }
                age++;
            }
            if (money >= costs)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {(money - costs):F2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {(costs - money):F2} dollars to survive.");
            }
        }
    }
}

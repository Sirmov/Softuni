using System;

namespace _06.Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double water = 20 * months;
            double internet = 15 * months;
            double electricity = 0;
            double other = 0;
            for (int i = 0; i < months; i++)
            {
                electricity += double.Parse(Console.ReadLine());
            }
            other = (water + internet + electricity);
            other += other * 0.20;
            Console.WriteLine($"Electricity: {electricity:F2} lv");
            Console.WriteLine($"Water: {water:F2} lv");
            Console.WriteLine($"Internet: {internet:F2} lv");
            Console.WriteLine($"Other: {other:F2} lv");
            Console.WriteLine($"Average: {(electricity + water + internet + other) / months:F2} lv");
        }
    }
}

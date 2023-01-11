using System;

namespace _01.Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double fee = double.Parse(Console.ReadLine());
            double sunbed = double.Parse(Console.ReadLine());
            double umbrella = double.Parse(Console.ReadLine());

            double price = fee * people;
            price += umbrella * Math.Ceiling(people / 2.00);
            price += sunbed * Math.Ceiling(people * 0.75);
            Console.WriteLine($"{price:F2} lv.");
        }
    }
}
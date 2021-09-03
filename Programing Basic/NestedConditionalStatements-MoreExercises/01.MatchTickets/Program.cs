using System;

namespace _01.MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double price = 0;

            if (people >= 1 && people <= 4)
            {
                budget -= budget * 0.75;
            }
            else if (people >= 5 && people <= 9)
            {
                budget -= budget * 0.60;
            }
            else if (people >= 10 && people <= 24)
            {
                budget -= budget * 0.50;
            }
            else if (people >= 25 && people <= 49)
            {
                budget -= budget * 0.40;
            }
            else if (people >= 50)
            {
                budget -= budget * 0.25;
            }

            switch (type)
            {
                case "VIP":
                    price = 499.99;
                    break;
                case "Normal":
                    price = 249.99;
                    break;
            }
            price *= people;

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget - price:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price - budget:F2} leva.");
            }
        }
    }
}

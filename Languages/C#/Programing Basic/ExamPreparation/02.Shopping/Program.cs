using System;

namespace _02.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int GPU = int.Parse(Console.ReadLine());
            int CPU = int.Parse(Console.ReadLine());
            int RAM = int.Parse(Console.ReadLine());

            double price = GPU * 250;
            double CPUPrice = price * 0.35;
            double RAMPrice = price * 0.10;
            price += CPUPrice * CPU + RAMPrice * RAM;
            if (GPU > CPU)
            {
                price -= price * 0.15;
            }
            if (budget >= price)
            {
                Console.WriteLine($"You have {budget - price:F2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price - budget:F2} leva more!");
            }
        }
    }
}

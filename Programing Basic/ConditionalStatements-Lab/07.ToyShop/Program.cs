using System;

namespace _07.ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            const double puzzelPrice = 2.60;
            const double dollPrice = 3.00;
            const double bearPrice = 4.10;
            const double minionPrice = 8.20;
            const double truckPrice = 2.00;

            double vacationPrice = double.Parse(Console.ReadLine());
            int puzzels = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());
            int toys = puzzels + dolls + bears + minions + trucks;

            double income = puzzels * puzzelPrice +
            dolls * dollPrice + bears * bearPrice +
            minions * minionPrice + trucks * truckPrice;

            if (toys >= 50)
            {
                income -= income * 0.25;
            }
            income -= income * 0.10;

            if (income >= vacationPrice)
            {
                Console.WriteLine($"Yes! {income - vacationPrice:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {vacationPrice - income:F2} lv needed.");
            }
        }
    }
}

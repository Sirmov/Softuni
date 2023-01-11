using System;

namespace _08.FuelTank_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());
            string card = Console.ReadLine();

            double price = 0;
            double gasoline = 2.22;
            double diesel = 2.33;
            double gas = 0.93;

            if (card == "Yes")
            {
                gasoline -= 0.18;
                diesel -= 0.12;
                gas -= 0.08;
            }

            if (fuelType == "Gasoline")
            {
                price = gasoline * liters;
            }
            else if (fuelType == "Diesel")
            {
                price = diesel * liters;
            }
            else
            {
                price = gas * liters;
            }

            if (liters >= 20 && liters <= 25)
            {
                price -= price * 0.08;
            }
            else if (liters > 25)
            {
                price -= price * 0.1;
            }
            Console.WriteLine($"{price:F2} lv.");
        }
    }
}

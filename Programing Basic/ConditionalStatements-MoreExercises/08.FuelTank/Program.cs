using System;

namespace _08.FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            int liters = int.Parse(Console.ReadLine());

            if (fuelType != "Gas" && fuelType != "Gasoline" && fuelType != "Diesel")
            {
                Console.WriteLine("Invalid fuel!");
            }
            else if (liters >= 25)
            {
                Console.WriteLine($"You have enough {fuelType.ToLower()}.");
            }
            else
            {
                Console.WriteLine($"Fill your tank with {fuelType.ToLower()}!");
            }
        }
    }
}

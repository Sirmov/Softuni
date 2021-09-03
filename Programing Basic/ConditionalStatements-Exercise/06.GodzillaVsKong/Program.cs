using System;

namespace _06.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double outfitPrice = double.Parse(Console.ReadLine());
            
            double costs = statists * outfitPrice;
            double decor = budget * 0.10;
            
            if (statists > 150)
            {
                costs -= costs * 0.10;
            }
            costs += decor;
            
            if (budget >= costs)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - costs:F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {costs - budget:F2} leva more.");
            }
        }
    }
}

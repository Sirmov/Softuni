using System;

namespace _03.Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyardArea = int.Parse(Console.ReadLine());
            double grapesPerArea = double.Parse(Console.ReadLine());
            int wineForSale = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grapes = (vineyardArea * grapesPerArea) * 0.40;
            double wine = grapes / 2.5;

            if (wine >= wineForSale)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
                Console.WriteLine($"{Math.Ceiling(wine-wineForSale)} liters left -> {Math.Ceiling((wine-wineForSale) / workers)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(wineForSale - wine)} liters wine needed.");
            }
        }
    }
}

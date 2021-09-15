using System;

namespace _07.FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double bananaPrice;
            double orangePrice;
            double raspberryPrice;
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananaKg = double.Parse(Console.ReadLine());
            double orangeKg = double.Parse(Console.ReadLine());
            double raspberryKg = double.Parse(Console.ReadLine());
            double strawberryKg = double.Parse(Console.ReadLine());
            
            raspberryPrice = strawberryPrice / 2;
            orangePrice = raspberryPrice - raspberryPrice * 0.40;
            bananaPrice = raspberryPrice - raspberryPrice * 0.80;

            double sum = bananaKg * bananaPrice + orangeKg * orangePrice + raspberryKg * raspberryPrice + strawberryKg * strawberryPrice;
            Console.WriteLine($"{sum:F2}");
        }
    }
}

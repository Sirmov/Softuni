using System;

namespace _07.FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double mongoliiPrice = 3.25;
            double zqmbuliPrice = 4.00;
            double rosesPrice = 3.50;
            double cactusesPrice = 8.00;

            int mongolii = int.Parse(Console.ReadLine());
            int zqmbuli = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactuses = int.Parse(Console.ReadLine());
            double prizePrice = double.Parse(Console.ReadLine());

            double income = mongolii * mongoliiPrice + zqmbuli * zqmbuliPrice + roses * rosesPrice + cactuses * cactusesPrice;
            income -= income * 0.05;

            if (income >= prizePrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(income - prizePrice)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(prizePrice - income)} leva.");
            }
        }
    }
}

using System;

namespace _03.Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemumsCount = int.Parse(Console.ReadLine());
            int rosesCount = int.Parse(Console.ReadLine());
            int tulipsCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string isHoliday = Console.ReadLine();
            double price = 0;

            switch (season)
            {
                case "Spring":
                case "Summer":
                        price += chrysanthemumsCount * 2.00;
                        price += rosesCount * 4.10;
                        price += tulipsCount * 2.50;
                    break;
                case "Autumn":
                case "Winter":
                        price += chrysanthemumsCount * 3.75;
                        price += rosesCount * 4.50;
                        price += tulipsCount * 4.15;
                    break;
            }
            if (isHoliday == "Y")
            {
                price += price * 0.15;
            }
            if (tulipsCount > 7 && season == "Spring")
            {
                price -= price * 0.05;
            }
            if (rosesCount >= 10 && season == "Winter")
            {
                price -= price * 0.10;
            }
            if ((chrysanthemumsCount + rosesCount + tulipsCount) > 20)
            {
                price -= price * 0.20;
            }
            price += 2;
            Console.WriteLine($"{price:F2}");
        }
    }
}

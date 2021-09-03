using System;

namespace _04.CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string clas = "";
            string car = "";
            double price = 0.00;

            if (budget <= 100)
            {
                clas = "Economy class";
                switch (season)
                {
                    case "Summer":
                        car = "Cabrio";
                        price = budget * 0.35;
                        break;
                    case "Winter":
                        car = "Jeep";
                        price = budget * 0.65;
                        break;
                }

            }
            else if (budget > 100 && budget <= 500)
            {
                clas = "Compact class";
                switch (season)
                {
                    case "Summer":
                        car = "Cabrio";
                        price = budget * 0.45;
                        break;
                    case "Winter":
                        car = "Jeep";
                        price = budget * 0.80;
                        break;
                }
            }
            else if (budget > 500)
            {
                clas = "Luxury class";
                car = "Jeep";
                price = budget * 0.90;
            }
            Console.WriteLine($"{clas}");
            Console.WriteLine($"{car} - {price:F2}");
        }
    }
}

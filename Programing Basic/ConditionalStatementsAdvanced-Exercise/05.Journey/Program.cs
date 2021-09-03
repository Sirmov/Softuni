using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            string placeToStay = "";
            double price = 0;

            if (budget <= 100)
            {
                destination = "Somewhere in Bulgaria";
                switch (season)
                {
                    case "summer":
                        placeToStay = "Camp";
                        price = 0.30 * budget;
                        break;
                    case "winter":
                        placeToStay = "Hotel";
                        price = 0.70 * budget;
                        break;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Somewhere in Balkans";
                switch (season)
                {
                    case "summer":
                        placeToStay = "Camp";
                        price = 0.40 * budget;
                        break;
                    case "winter":
                        placeToStay = "Hotel";
                        price = 0.80 * budget;
                        break;
                }
            }
            else
            {
                destination = "Somewhere in Europe";
                placeToStay = "Hotel";
                price = 0.90 * budget;
            }

            Console.WriteLine(destination);
            Console.WriteLine($"{placeToStay} - {price:F2}");
        }
    }
}

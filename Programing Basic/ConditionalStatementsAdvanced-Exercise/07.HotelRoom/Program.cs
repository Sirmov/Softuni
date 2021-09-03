using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studio = 0.00;
            double apartment = 0.00;
            double studioDiscount = 0.00;
            double apartmentDiscount = 0.00;
            switch (month)
            {
                case ("May"):
                    studio = 50 * nights;
                    apartment = 65 * nights;
                    if (nights > 7 && nights <= 14)
                    {
                        studioDiscount = 0.05 * studio;
                    }
                    if (nights > 14)
                    {
                        studioDiscount = 0.30 * studio;
                    }
                    break;
                case ("October"):
                    studio = 50 * nights;
                    apartment = 65 * nights;
                    if (nights > 7 && nights <= 14)
                    {
                        studioDiscount = 0.05 * studio;
                    }
                    if (nights > 14)
                    {
                        studioDiscount = 0.30 * studio;
                    }
                    break;
                case ("June"):
                    studio = 75.20 * nights;
                    apartment = 68.70 * nights;
                    if (nights > 14)
                    {
                        studioDiscount = 0.20 * studio;
                    }
                    break;
                case ("September"):
                    studio = 75.20 * nights;
                    apartment = 68.70 * nights;
                    if (nights > 14)
                    {
                        studioDiscount = 0.20 * studio;
                    }
                    break;
                case ("July"):
                    studio = 76 * nights;
                    apartment = 77 * nights;
                    break;
                case ("August"):
                    studio = 76 * nights;
                    apartment = 77 * nights;
                    break;
            }

            if (nights > 14)
            {
                apartmentDiscount = 0.10 * apartment;
            }
            studio -= studioDiscount;
            apartment -= apartmentDiscount;
            Console.WriteLine($"Apartment: {apartment:F2} lv.");
            Console.WriteLine($"Studio: {studio:F2} lv.");
        }
    }
}
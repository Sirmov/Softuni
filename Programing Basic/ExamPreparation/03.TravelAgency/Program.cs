using System;

namespace _03.TravelAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string packet = Console.ReadLine();
            string isVip = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }

            double dayPrice = 0;
            double VIPDiscount = 0;
            switch (city)
            {
                case "Bansko":
                case "Borovets":
                    switch (packet)
                    {
                        case "withEquipment":
                            dayPrice += 100;
                            VIPDiscount = 0.10;
                            break;
                        case "noEquipment":
                            dayPrice += 80;
                            VIPDiscount = 0.05;
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            return;
                            break;
                    }
                    break;
                case "Varna":
                case "Burgas":
                    switch (packet)
                    {
                        case "withBreakfast":
                            dayPrice += 130;
                            VIPDiscount = 0.12;
                            break;
                        case "noBreakfast":
                            dayPrice += 100;
                            VIPDiscount = 0.07;
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            return;
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    return;
                    break;
            }
            double price = dayPrice * days;
            if (days > 7)
            {
                price -= dayPrice;
            }
            if (isVip == "yes")
            {
                price -= price * VIPDiscount;
            }
            Console.WriteLine($"The price is {price:F2}lv! Have a nice time!");
        }
    }
}

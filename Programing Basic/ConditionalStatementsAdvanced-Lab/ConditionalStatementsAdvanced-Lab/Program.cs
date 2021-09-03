using System;

namespace _13.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine()) - 1;
            string room = Console.ReadLine();
            string feedback = Console.ReadLine();

            double roomPrice = 0;
            double price = 0;

            switch (room)
            {
                case "room for one person":
                    roomPrice = 18.00;
                    break;
                case "apartment":
                    roomPrice = 25.00;
                    break;
                case "president apartment":
                    roomPrice = 35.00;
                    break;
            }

            price = roomPrice * days;

            switch (room)
            {
                case "apartment":
                    if (days < 10)
                    {
                        price -= price * 0.30;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        price -= price * 0.35;
                    }
                    else if (days > 15)
                    {
                        price -= price * 0.50;
                    }
                    break;
                
                case "president apartment":
                    if (days < 10)
                    {
                        price -= price * 0.10;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        price -= price * 0.15;
                    }
                    else if (days > 15)
                    {
                        price -= price * 0.20;
                    }
                    break;
            }

            if (feedback == "positive")
            {
                price += price * 0.25;
            }
            else
            {
                price -= price * 0.10;
            }

            Console.WriteLine($"{price:F2}");
        }
    }
}

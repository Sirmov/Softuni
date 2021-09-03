using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();
            
            double price = 0;
            double discount = 0;

            switch (groupType)
            {
                case "Students":
                    if (day == "Friday")
                    {
                        price = 8.45;
                    }
                    else if (day == "Saturday")
                    {
                        price = 9.8;
                    }
                    else if (day == "Sunday")
                    {
                        price = 10.46;
                    }
                    break;

                case "Business":
                    if (day == "Friday")
                    {
                        price = 10.9;
                    }
                    else if (day == "Saturday")
                    {
                        price = 15.6;
                    }
                    else if (day == "Sunday")
                    {
                        price = 16;
                    }
                    break;

                case "Regular":
                    if (day == "Friday")
                    {
                        price = 15;
                    }
                    else if (day == "Saturday")
                    {
                        price = 20;
                    }
                    else if (day == "Sunday")
                    {
                        price = 22.5;
                    }
                    break;
            }

            if (groupType == "Students" && people >= 30)
            {
                discount = 0.15;
            }
            if (groupType == "Business" && people >= 100)
            {
                people -= 10;
            }
            if (groupType == "Regular" && people >= 10 && people <= 20)
            {
                discount = 0.05;
            }

            double totalPrice = people * price;
            
            if (discount != 0)
            {
                totalPrice -= totalPrice * discount;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}

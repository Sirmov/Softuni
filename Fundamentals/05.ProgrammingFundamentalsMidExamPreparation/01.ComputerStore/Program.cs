using System;
using System.Data;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalPrice = 0;
            double taxes = 0;
            string input = Console.ReadLine();


            while (input != "special" && input != "regular")
            {
                double price = double.Parse(input);
                double tax = price * 0.2;

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                totalPrice += price;
                taxes += tax;

                input = Console.ReadLine();
            }

            if (totalPrice <= 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalPrice:F2}$");
            Console.WriteLine($"Taxes: {taxes:F2}$");
            Console.WriteLine("-----------");
            totalPrice += taxes;
            if (input == "special")
            {
                totalPrice -= totalPrice * 0.1;
            }
            Console.WriteLine($"Total price: {totalPrice:F2}$");
        }
    }
}

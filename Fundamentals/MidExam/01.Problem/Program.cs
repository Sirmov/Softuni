using System;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            for (int i = 0; i < orders; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsules = int.Parse(Console.ReadLine());
                double price = (days * capsules) * capsulePrice;
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
                totalPrice += price;
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}

using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, double[]> products = new Dictionary<string, double[]>();
            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] args = input.Split();
                string name = args[0];
                double price = double.Parse(args[1]);
                int quantity = int.Parse(args[2]);

                if (!products.ContainsKey(name))
                {
                    products.Add(name, new double[2]);
                }

                products[name][0] = price;
                products[name][1] += quantity;

                input = Console.ReadLine();
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value[0] * product.Value[1]:F2}");
            }
        }
    }
}

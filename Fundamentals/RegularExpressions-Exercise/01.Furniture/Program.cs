using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(>>(?<name>[\w]+)<<(?<price>[0-9]+(?:\.[0-9]+)?)!(?<quantity>[0-9]+))");
            List<string> furnitures = new List<string>();
            double totalPrice = 0;
            string input = Console.ReadLine();

            while (input != "Purchase")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string name = match.Groups["name"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    furnitures.Add(name);
                    totalPrice += price * quantity;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            if (furnitures.Count > 0)
            {
                Console.WriteLine(string.Join("\n", furnitures));
            }
            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}

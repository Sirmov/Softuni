using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"%(?<name>[A-Z][a-z]+)%([^\|\$%\.]+)?<(?<product>[\w]+)>([^\|\$%\.]+)?\|(?<count>[0-9]+)\|([^\|\$%\.\d]+)?(?<price>[0-9]+(?:\.[0-9]+)?)\$");
            double totalIncome = 0;
            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value) * count;

                    Console.WriteLine($"{name}: {product} - {price:F2}");
                    totalIncome += price;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}

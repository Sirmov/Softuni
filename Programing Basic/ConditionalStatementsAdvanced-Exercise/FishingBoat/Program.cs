using System;

namespace Practice
{
	class Program
	{
		static void Main(string[] args)
		{
			int budget = int.Parse(Console.ReadLine());
			string season = Console.ReadLine();
			int members = int.Parse(Console.ReadLine());
			double price = 0.00;
			double discount = 0.00;
			double extraDiscount = 0.00;
			switch (season)
			{
				case ("Spring"):
					price = 3000;
					break;
				case ("Summer"):
					price = 4200;
					break;
				case ("Autumn"):
					price = 4200;
					break;
				case ("Winter"):
					price = 2600;
					break;
			}

			if (members <= 6)
			{
				discount = price * 0.10;
			}
			else if (members >= 7 && members <= 11)
			{
				discount = price * 0.15;
			}
			else if (members >= 12)
			{
				discount = price * 0.25;
			}
			price -= discount;
			if (members % 2 == 0 && season != "Autumn")
			{
				extraDiscount = price * 0.05;
			}
			price -= extraDiscount;
			if (budget >= price)
			{
				Console.WriteLine($"Yes! You have {(budget - price):F2} leva left.");
			}
			else
			{
				Console.WriteLine($"Not enough money! You need {(price - budget):F2} leva.");
			}
		}
	}
}
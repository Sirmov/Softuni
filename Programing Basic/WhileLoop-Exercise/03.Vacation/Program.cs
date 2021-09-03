using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double holiday = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());
            string operation = "";
            double amount = 0;
            int spend = 0;
            int days = 1;
            while (true)
            {
                operation = Console.ReadLine();
                switch (operation)
                {
                    case "spend":
                        amount = double.Parse(Console.ReadLine());
                        if (amount > money)
                        {
                            money = 0;
                            spend++;
                        }
                        else
                        {
                            money -= amount;
                            spend++;
                        }
                        break;
                    case "save":
                        amount = double.Parse(Console.ReadLine());
                        money += amount;
                        spend = 0;
                        break;
                }
                if (spend >= 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(days);
                    break;
                }
                if (money >= holiday)
                {
                    Console.WriteLine($"You saved the money for {days} days.");
                    break;
                }
                days++;
            }
        }
    }
}

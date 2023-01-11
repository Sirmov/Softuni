using System;

namespace _05.Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double target = double.Parse(Console.ReadLine());
            string coctail = Console.ReadLine();
            double money = 0;
            while (coctail != "Party!")
            {
                
                int countiti = int.Parse(Console.ReadLine());
                double price = coctail.Length * countiti;
                if (price % 2 != 0)
                {
                    price -= price * 0.25;
                }
                money += price;
                if (money >= target)
                {
                    break;
                }
                coctail = Console.ReadLine();
            }
            if (coctail == "Party!")
            {
                Console.WriteLine($"We need {target - money:F2} leva more.");
            }
            if (money >= target)
            {
                Console.WriteLine($"Target acquired.");
            }
            Console.WriteLine($"Club income - {money:F2} leva.");
        }
    }
}

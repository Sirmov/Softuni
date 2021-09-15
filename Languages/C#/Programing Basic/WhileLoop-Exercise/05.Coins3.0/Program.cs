using System;

namespace _05.Coins3._0
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double converter = change * 100;
            int cents = (int)converter;
            int coins = 0;

            while (cents > 0)
            {
                if (cents - 200 >= 0)
                {
                    coins++;
                    cents -= 200;
                }
                else if (cents - 100 >= 0)
                {
                    coins++;
                    cents -= 100;
                }
                else if (cents - 50 >= 0)
                {
                    coins++;
                    cents -= 50;
                }
                else if (cents - 20 >= 0)
                {
                    coins++;
                    cents -= 20;
                }
                else if (cents - 10 >= 0)
                {
                    coins++;
                    cents -= 10;
                }
                else if (cents - 5 >= 0)
                {
                    coins++;
                    cents -= 5;
                }
                else if (cents - 2 >= 0)
                {
                    coins++;
                    cents -= 2;
                }
                else if (cents - 1 >= 0)
                {
                    coins++;
                    cents -= 1;
                }
            }
            Console.WriteLine(coins);
        }
    }
}

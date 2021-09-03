using System;

namespace _11.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int lilyAge = int.Parse(Console.ReadLine());
            double washingMachine = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());
            int toys = 0;
            double money = 0;
            for (int i = 1; i <= lilyAge; i++)
            {
                if (i % 2 == 0)
                {
                    money += 10 * (i / 2);
                    money--;
                }
                else
                {
                    toys++;
                }
            }
            money += toys * toyPrice;
            if (money >= washingMachine)
            {
                Console.WriteLine($"Yes! {(money - washingMachine):F2}");
            }
            else
            {
                Console.WriteLine($"No! {(washingMachine - money):F2}");
            }
        }
    }
}

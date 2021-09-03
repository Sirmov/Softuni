using System;

namespace _05.Coins2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double converter = change * 100;
            int cents = (int)converter;
            int remeinder = 0;
            int coins = 0;

            remeinder = cents % 200;
            coins += cents / 200;
            cents = remeinder;

            remeinder = cents % 100;
            coins += cents / 100;
            cents = remeinder;

            remeinder = cents % 50;
            coins += cents / 50;
            cents = remeinder;

            remeinder = cents % 20;
            coins += cents / 20;
            cents = remeinder;

            remeinder = cents % 10;
            coins += cents / 10;
            cents = remeinder;

            remeinder = cents % 5;
            coins += cents / 5;
            cents = remeinder;

            remeinder = cents % 2;
            coins += cents / 2;
            cents = remeinder;

            remeinder = cents % 1;
            coins += cents / 1;
            cents = remeinder;

            Console.WriteLine(coins);
        }
    }
}

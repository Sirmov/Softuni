using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double currentChange = 0;
            double coins2Lv = 0;
            double coins1Lv = 0;
            double coins50St = 0;
            double coins20St = 0;
            double coins10St = 0;
            double coins5St = 0;
            double coins2St = 0;
            double coins1St = 0;
            double coins = 0;
            while (true)
            {
                coins2Lv = Math.Floor(change / 2);
                currentChange = 2 * coins2Lv;
                change -= currentChange;
                change = Math.Round(change, 2);
                coins = coins2Lv + coins1Lv + coins50St + coins20St + coins10St + coins5St + coins2St + coins1St;
                if (change == 0)
                {
                    Console.WriteLine(coins);
                    break;
                }

                coins1Lv = Math.Floor(change / 1);
                currentChange = 1 * coins1Lv;
                change -= currentChange;
                change = Math.Round(change, 2);
                coins = coins2Lv + coins1Lv + coins50St + coins20St + coins10St + coins5St + coins2St + coins1St;
                if (change == 0)
                {
                    Console.WriteLine(coins);
                    break;
                }

                coins50St = Math.Floor(change / 0.50);
                currentChange = 0.50 * coins50St;
                change -= currentChange;
                change = Math.Round(change, 2);
                coins = coins2Lv + coins1Lv + coins50St + coins20St + coins10St + coins5St + coins2St + coins1St;
                if (change == 0)
                {
                    Console.WriteLine(coins);
                    break;
                }

                coins20St = Math.Floor(change / 0.20);
                currentChange = 0.20 * coins20St;
                change -= currentChange;
                change = Math.Round(change, 2);
                coins = coins2Lv + coins1Lv + coins50St + coins20St + coins10St + coins5St + coins2St + coins1St;
                if (change == 0)
                {
                    Console.WriteLine(coins);
                    break;
                }

                coins10St = Math.Floor(change / 0.10);
                currentChange = 0.10 * coins10St;
                change -= currentChange;
                change = Math.Round(change, 2);
                coins = coins2Lv + coins1Lv + coins50St + coins20St + coins10St + coins5St + coins2St + coins1St;
                if (change == 0)
                {
                    Console.WriteLine(coins);
                    break;
                }

                coins5St = Math.Floor(change / 0.05);
                currentChange = 0.05 * coins5St;
                change -= currentChange;
                change = Math.Round(change, 2);
                coins = coins2Lv + coins1Lv + coins50St + coins20St + coins10St + coins5St + coins2St + coins1St;
                if (change == 0)
                {
                    Console.WriteLine(coins);
                    break;
                }

                coins2St = Math.Floor(change / 0.02);
                currentChange = 0.02 * coins2St;
                change -= currentChange;
                change = Math.Round(change, 2);
                coins = coins2Lv + coins1Lv + coins50St + coins20St + coins10St + coins5St + coins2St + coins1St;
                if (change == 0)
                {
                    Console.WriteLine(coins);
                    break;
                }

                coins1St = Math.Floor(change / 0.01);
                currentChange = 0.01 * coins1St;
                change -= currentChange;
                change = Math.Round(change, 2);
                coins = coins2Lv + coins1Lv + coins50St + coins20St + coins10St + coins5St + coins2St + coins1St;
                if (change == 0)
                {
                    Console.WriteLine(coins);
                    break;
                }
            }
        }
    }
}

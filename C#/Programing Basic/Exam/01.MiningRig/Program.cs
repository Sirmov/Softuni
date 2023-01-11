using System;

namespace _01.MiningRig
{
    class Program
    {
        static void Main(string[] args)
        {
            int videocard = int.Parse(Console.ReadLine());
            int adapter = int.Parse(Console.ReadLine());
            double dailyElectricity = double.Parse(Console.ReadLine());
            double dailyProfit = double.Parse(Console.ReadLine());

            int investment = videocard * 13 + adapter * 13 + 1000;
            dailyProfit -= dailyElectricity;
            dailyProfit *= 13;
            double returnDays = Math.Ceiling(investment / dailyProfit);
            Console.WriteLine(investment);
            Console.WriteLine(returnDays);
        }
    }
}

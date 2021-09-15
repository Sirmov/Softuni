using System;

namespace _02.BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniorCyclists = int.Parse(Console.ReadLine());
            int seniorCyclists = int.Parse(Console.ReadLine());
            string raceType = Console.ReadLine();
            double money = 0;

            //Група   trail   cross - country   downhill road
            //juniors 5.50    8                  12.25   20
            //seniors 7       9.50               13.75   21.50

            switch (raceType)
            {
                case "trail":
                    money += juniorCyclists * 5.50;
                    money += seniorCyclists * 7.00;
                    break;
                case "cross-country":
                    money += juniorCyclists * 8.00;
                    money += seniorCyclists * 9.50;
                    if ((juniorCyclists + seniorCyclists) >= 50)
                    {
                        money -= money * 0.25;
                    }
                    break;
                case "downhill":
                    money += juniorCyclists * 12.25;
                    money += seniorCyclists * 13.75;
                    break;
                case "road":
                    money += juniorCyclists * 20.00;
                    money += seniorCyclists * 21.50;
                    break;
            }
            money -= money * 0.05;
            Console.WriteLine($"{money:F2}");
        }
    }
}

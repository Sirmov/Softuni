using System;

namespace _03.Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int cargo = int.Parse(Console.ReadLine());
            int currentCargoWeight;
            int cargoWeight = 0;
            double bus = 0;
            double truck = 0;
            double train =  0;
            double price = 0;
            for (int i = 0; i < cargo; i++)
            {
                currentCargoWeight = int.Parse(Console.ReadLine());
                cargoWeight += currentCargoWeight;
                if (currentCargoWeight <= 3)
                {
                    bus += currentCargoWeight;
                }
                else if (currentCargoWeight >= 4 && currentCargoWeight <= 11)
                {
                    truck += currentCargoWeight;
                }
                else if (currentCargoWeight >= 12)
                {
                    train += currentCargoWeight;
                }
            }
            price = (bus * 200 + truck * 175 + train * 120) / cargoWeight;
            double busProcent = bus / cargoWeight * 100;
            double truckProcent = truck / cargoWeight * 100;
            double trainProcent = train / cargoWeight * 100;
            Console.WriteLine($"{(price):F2}");
            Console.WriteLine($"{(busProcent):F2}%");
            Console.WriteLine($"{(truckProcent):F2}%");
            Console.WriteLine($"{(trainProcent):F2}%");
        }
    }
}

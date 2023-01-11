using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, new Car(model, fuelAmount, fuelConsumptionPerKilometer));
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArgs = command.Split();
                string operation = commandArgs[0];

                if (operation == "Drive")
                {
                    string carModel = commandArgs[1];
                    double distance = double.Parse(commandArgs[2]);

                    if (cars.ContainsKey(carModel))
                    {
                        cars[carModel].Drive(distance);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var (key, car) in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}

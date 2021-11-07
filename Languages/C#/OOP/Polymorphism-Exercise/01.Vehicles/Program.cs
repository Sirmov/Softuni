using System;

namespace _01.Vehicles
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            Car car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckInfo = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                string operation = arguments[0];
                string vehicle = arguments[1];

                if (operation == "Drive")
                {
                    double kilometers = double.Parse(arguments[2]);

                    if (vehicle == "Car")
                    {
                        car.Drive(kilometers);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Drive(kilometers);
                    }
                }
                else if (operation == "Refuel")
                {
                    double liters = double.Parse(arguments[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.Fuel:F2}");
            Console.WriteLine($"Truck: {truck.Fuel:F2}");
        }
    }
}
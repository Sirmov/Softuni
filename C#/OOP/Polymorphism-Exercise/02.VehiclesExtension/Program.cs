using System;

namespace _02.VehiclesExtension
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);
            Car car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckInfo = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);
            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busInfo = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

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
                    else if (vehicle == "Bus")
                    {
                        bus.Drive(kilometers);
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
                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(liters);
                    }
                }
                else if (operation == "DriveEmpty")
                {
                    double kilometers = double.Parse(arguments[2]);

                    bus.DriveEmpty(kilometers);
                }
            }

            Console.WriteLine($"Car: {car.Fuel:F2}");
            Console.WriteLine($"Truck: {truck.Fuel:F2}");
            Console.WriteLine($"Bus: {bus.Fuel:F2}");
        }
    }
}
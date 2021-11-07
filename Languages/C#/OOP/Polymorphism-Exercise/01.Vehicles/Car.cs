using System;

namespace _01.Vehicles
{
    internal class Car : IVehicle
    {
        private const double AirConditioningFuelConsumption = 0.9;

        public Car(double fuel, double fuelConsumption)
        {
            Fuel = fuel;
            FuelConsumption = fuelConsumption + AirConditioningFuelConsumption;
        }

        public double Fuel { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double kilometers)
        {
            double fuelNeeded = this.FuelConsumption * kilometers;

            if (fuelNeeded > this.Fuel)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                this.Fuel -= fuelNeeded;
                Console.WriteLine($"Car travelled {kilometers} km");
            }
        }

        public void Refuel(double liters)
        {
            this.Fuel += liters;
        }
    }
}
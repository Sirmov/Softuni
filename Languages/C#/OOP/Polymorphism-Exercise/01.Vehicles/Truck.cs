using System;

namespace _01.Vehicles
{
    internal class Truck : IVehicle
    {
        private const double AirConditioningFuelConsumption = 1.6;

        public Truck(double fuel, double fuelConsumption)
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
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                this.Fuel -= fuelNeeded;
                Console.WriteLine($"Truck travelled {kilometers} km");
            }
        }

        public void Refuel(double liters)
        {
            this.Fuel += liters * 0.95;
        }
    }
}
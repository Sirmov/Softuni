using System;

namespace _02.VehiclesExtension
{
    internal class Truck : IVehicle
    {
        private const double AirConditioningFuelConsumption = 1.6;

        public Truck(double fuel, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.Fuel = fuel > tankCapacity ? 0 : fuel;
            this.FuelConsumption = fuelConsumption + AirConditioningFuelConsumption;
        }

        public double Fuel { get; set; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

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
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.Fuel + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                this.Fuel += liters * 0.95;
            }
        }
    }
}
using System;

namespace _02.VehiclesExtension
{
    internal class Bus : IVehicle
    {
        private const double AirConditioningFuelConsumption = 1.4;

        public Bus(double fuel, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.Fuel = fuel > tankCapacity ? 0 : fuel;
            this.FuelConsumption = fuelConsumption;
        }

        public double Fuel { get; set; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public void Drive(double kilometers)
        {
            double fuelNeeded = (this.FuelConsumption + AirConditioningFuelConsumption) * kilometers;

            if (fuelNeeded > this.Fuel)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                this.Fuel -= fuelNeeded;
                Console.WriteLine($"Bus travelled {kilometers} km");
            }
        }

        public void DriveEmpty(double kilometers)
        {
            double fuelNeeded = this.FuelConsumption * kilometers;

            if (fuelNeeded > this.Fuel)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                this.Fuel -= fuelNeeded;
                Console.WriteLine($"Bus travelled {kilometers} km");
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
                this.Fuel += liters;
            }
        }
    }
}
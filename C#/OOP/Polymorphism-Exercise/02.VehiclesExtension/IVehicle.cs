namespace _02.VehiclesExtension
{
    internal interface IVehicle
    {
        public double Fuel { get; set; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public void Drive(double kilometers);

        public void Refuel(double liters);
    }
}
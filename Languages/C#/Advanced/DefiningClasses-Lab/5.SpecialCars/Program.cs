using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            int count = 0;

            string input = Console.ReadLine();
            while (input != "No more tires")
            {
                tires.Add(new Tire[4]);
                string[] tiresData = input.Split();

                for (int i = 0; i < tiresData.Length; i += 2)
                {
                    int year = int.Parse(tiresData[i]);
                    double pressure = double.Parse(tiresData[i + 1]);
                    Tire tire = new Tire(year, pressure);
                    tires[count][i / 2] = tire;
                }

                count++;
                input = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();

            input = Console.ReadLine();
            while (input != "Engines done")
            {
                string[] engineData = input.Split();

                int horsePower = int.Parse(engineData[0]);
                double cubicCapacity = double.Parse(engineData[1]);
                engines.Add(new Engine(horsePower, cubicCapacity));

                input = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();

            input = Console.ReadLine();
            while (input != "Show special")
            {
                string[] carData = input.Split();

                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                Engine engine = engines[int.Parse(carData[5])];
                Tire[] tireSet = tires[int.Parse(carData[6])];

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tireSet));

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                double tirePressureSum = car.Tires.Sum(t => t.Pressure);

                if (car.Year >= 2017 && car.Engine.HorsePower > 330
                    && tirePressureSum >= 9 && tirePressureSum <= 10)
                {
                    car.Drive(20 / 100.0);

                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}

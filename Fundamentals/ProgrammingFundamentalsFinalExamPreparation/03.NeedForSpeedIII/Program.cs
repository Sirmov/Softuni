using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine().Split("|");

                if (!cars.ContainsKey(car[0]))
                {
                    cars.Add(car[0], new Car(int.Parse(car[1]), int.Parse(car[2])));
                }
            }

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] commandArgs = command.Split(" : ");
                string operation = commandArgs[0];
                string car = commandArgs[1];

                if (operation == "Drive")
                {
                    if (cars[car].Drive(car, int.Parse(commandArgs[2]), int.Parse(commandArgs[3])))
                    {
                        cars.Remove(car);
                    }
                }
                else if (operation == "Refuel")
                {
                    cars[car].Refuel(car, int.Parse(commandArgs[2]));
                }
                else if (operation == "Revert")
                {
                    cars[car].Revert(car, int.Parse(commandArgs[2]));
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }

    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public Car(int mileage, int fuel)
        {
            Mileage = mileage;
            Fuel = fuel;
        }

        public bool Drive(string car, int distance, int fuel)
        {
            if (Fuel < fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
            else
            {
                Fuel -= fuel;
                Mileage += distance;
                Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                if (Mileage >= 100000)
                {
                    Console.WriteLine($"Time to sell the {car}!");
                    return true;
                }
            }

            return false;
        }

        public void Refuel(string car, int fuel)
        {
            if (Fuel + fuel > 75)
            {
                Console.WriteLine($"{car} refueled with {75 - Fuel} liters");
                Fuel = 75;
            }
            else
            {
                Fuel += fuel;
                Console.WriteLine($"{car} refueled with {fuel} liters");
            }
        }

        public void Revert(string car, int kilometers)
        {
            Mileage -= kilometers;

            if (Mileage < 10000)
            {
                Mileage = 10000;
            }
            else
            {
                Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
            }
        }
    }
}

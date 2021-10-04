using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                if (engineInfo.Length == 4)
                {
                    string displacement = engineInfo[2];
                    string efficiency = engineInfo[3];

                    engines.Add(model, new Engine(model, power, displacement, efficiency));
                }
                else if (engineInfo.Length == 3)
                {
                    bool isDisplacement = int.TryParse(engineInfo[2], out _);

                    if (isDisplacement)
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        engines.Add(model, new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        engines.Add(model, new Engine(model, power, efficiency));
                    }
                }
                else if (engineInfo.Length == 2)
                {
                    engines.Add(model, new Engine(model, power));
                }
            }

            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engineModel = carInfo[1];

                if (carInfo.Length == 4)
                {
                    string weight = carInfo[2];
                    string color = carInfo[3];

                    cars.Add(new Car(model, engines[engineModel], weight, color));
                }
                else if (carInfo.Length == 3)
                {
                    bool isWeight = int.TryParse(carInfo[2], out _);

                    if (isWeight)
                    {
                        int weight = int.Parse(carInfo[2]);
                        cars.Add(new Car(model, engines[engineModel], weight));
                    }
                    else
                    {
                        string color = carInfo[2];
                        cars.Add(new Car(model, engines[engineModel], color));
                    }
                }
                else if (carInfo.Length == 2)
                {
                    cars.Add(new Car(model, engines[engineModel]));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}

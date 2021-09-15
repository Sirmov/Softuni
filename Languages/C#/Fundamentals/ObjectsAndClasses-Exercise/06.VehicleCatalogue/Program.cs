using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> cataloge = new List<Vehicle>(50);
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = inputArgs[0];
                string model = inputArgs[1];
                string color = inputArgs[2];
                int horsepower = int.Parse(inputArgs[3]);
                cataloge.Add(new Vehicle(type, model, color, horsepower));
                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "Close the Catalogue")
            {

                Console.WriteLine(cataloge.Find(x => x.Model == command).ToString());
                command = Console.ReadLine();
            }

            List<Vehicle> cars = cataloge.Where(x => x.Type == "Car").ToList();
            List<Vehicle> trucks = cataloge.Where(x => x.Type == "Truck").ToList();
            Console.WriteLine($"Cars have average horsepower of: {GetAverageHorsepower(cars):F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {GetAverageHorsepower(trucks):F2}.");
        }

        private static double GetAverageHorsepower(List<Vehicle> vehicles)
        {
            double sum = 0;
            if (vehicles.Count < 1)
            {
                return sum;
            }
            foreach (var vehicle in vehicles)
            {
                sum += vehicle.Horsepower;
            }
            return sum / vehicles.Count;
        }
    }

    class Vehicle
    {
        private string type;
        private string model;
        private string color;
        private int horsepower;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public int Horsepower
        {
            get { return horsepower; }
            set { horsepower = value; }
        }

        public Vehicle(string type, string model, string color, int horsepower)
        {
            this.type = char.ToUpper(type[0]) + type.Substring(1);
            this.model = model;
            this.color = color;
            this.horsepower = horsepower;
        }

        public override string ToString()
        {
            return $"Type: {type}\nModel: {model}\nColor: {color}\nHorsepower: {horsepower}";
        }
    }
}

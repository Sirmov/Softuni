using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    class Car
    {
        public Car(string model, int engineSpeed, int enginePower,
            int cargoWeight, string cargoType,
            double tire1Pressure, int tire1Age,
            double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age,
            double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoWeight, cargoType);
            Tires = new Tire[4];
            Tires[0] = new Tire(tire1Age, tire1Pressure);
            Tires[1] = new Tire(tire2Age, tire2Pressure);
            Tires[2] = new Tire(tire3Age, tire3Pressure);
            Tires[3] = new Tire(tire4Age, tire4Pressure);
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}

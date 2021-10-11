using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.Append(Engine.ToString());
            sb.AppendLine($"  Weight: {(Weight.HasValue ? Weight.Value.ToString() : "n/a")}");
            sb.Append($"  Color: {Color ?? "n/a"}");

            return sb.ToString();
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

    }
}

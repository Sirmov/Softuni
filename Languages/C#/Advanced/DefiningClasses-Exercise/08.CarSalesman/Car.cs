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
            Weight = null;
            Color = null;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight.ToString();
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, string weight, string color) : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            sb.AppendLine($"    Displacement: {Engine.Displacement ?? "n/a"}");
            sb.AppendLine($"    Efficiency: {Engine.Efficiency ?? "n/a"}");
            sb.AppendLine($"  Weight: {Weight ?? "n/a"}");
            sb.Append($"  Color: {Color ?? "n/a"}");

            return sb.ToString();
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Topping
    {
        // double weight

        private const double defaulModifier = 2;
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double Calories => defaulModifier * this.Weight * this.CaloriesModifier;

        private double CaloriesModifier
        {
            get
            {
                double modifier = 1;

                switch (this.Type.ToLower())
                {
                    case "meat":
                        modifier *= 1.2;
                        break;
                    case "veggies":
                        modifier *= 0.8;
                        break;
                    case "cheese":
                        modifier *= 1.1;
                        break;
                    case "sauce":
                        modifier *= 0.9;
                        break;
                }

                return modifier;
            }
        }

        private string Type
        {
            get => this.type;

            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }
        private double Weight
        {
            get => weight;

            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }
    }
}

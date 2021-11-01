using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Topping
    {
        private const double defaulModifier = 2;
        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            Type = type;
            Weight = weight;
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
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }
        private int Weight
        {
            get => weight;

            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        // Argument exceptions + const

        private const double defaultModifier = 2;
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private double CaloriesModifier
        {
            get
            {
                double modifier = 1;

                switch (this.flourType.ToLower())
                {
                    case "white":
                        modifier *= 1.5;
                        break;
                    case "wholegrain":
                        modifier *= 1;
                        break;
                }

                switch (this.bakingTechnique.ToLower())
                {
                    case "crispy":
                        modifier *= 0.9;
                        break;
                    case "chewy":
                        modifier *= 1.1;
                        break;
                    case "homemade":
                        modifier *= 1;
                        break;
                }

                return modifier;
            }
        }

        public double Calories => defaultModifier * this.Weight * this.CaloriesModifier;

        private string FlourType
        {
            get => flourType;

            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        private string BakingTechnique
        {
            get => bakingTechnique;

            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        private double Weight
        {
            get => weight;

            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }
    }
}

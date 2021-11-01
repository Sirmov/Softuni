using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Dough
    {
        private const double defaultModifier = 2;
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
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
                    throw new Exception("Invalid type of dough.");
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
                    throw new Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        private int Weight
        {
            get => weight;

            set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }
    }
}

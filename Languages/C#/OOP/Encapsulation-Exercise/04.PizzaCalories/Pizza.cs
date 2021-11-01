using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) ||
                    value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get => this.dough; set => this.dough = value; }

        public int ToppingsCount => this.toppings.Count;

        public double Calories
        {
            get
            {
                double calories = this.Dough.Calories;

                foreach (var topping in this.toppings)
                {
                    calories += topping.Calories;
                }

                return calories;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (ToppingsCount == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }
    }
}

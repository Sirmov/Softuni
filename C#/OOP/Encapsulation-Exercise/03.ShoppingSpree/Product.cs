using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    class Product
    {
        private string name;
        private int cost;

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }

                this.name = value;
            }
        }
        public int Cost
        {
            get => this.cost;

            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

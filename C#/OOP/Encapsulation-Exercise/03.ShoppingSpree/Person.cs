using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    class Person
    {
        private string name;
        private int money;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
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
        public int Money
        {
            get => this.money;

            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> Products { get; set; }

        public void PurchaseProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
                return;
            }

            this.Money -= product.Cost;
            this.Products.Add(product);
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Animal
    {
        protected string name;
        protected string favoriteFood;

        public Animal(string name, string favoriteFood)
        {
            this.name = name;
            this.favoriteFood = favoriteFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.name} and my favorite food is {this.favoriteFood}";
        }
    }
}
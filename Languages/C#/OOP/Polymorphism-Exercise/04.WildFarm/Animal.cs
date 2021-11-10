using System;

namespace _04.WildFarm
{
    internal abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public int FoodEaten { get; set; }

        public abstract string[] EatableFoods { get; set; }

        protected abstract double Growth {  get; set; }

        public abstract void ProduceSound();

        public void Eat(Food food)
        {
            if (!CanEat(food))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * this.Growth;
            }
        }

        private bool CanEat(Food food)
        {
            foreach (var item in EatableFoods)
            {
                if (item == food.GetType().Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

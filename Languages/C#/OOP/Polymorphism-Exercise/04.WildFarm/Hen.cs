using System;

namespace _04.WildFarm
{
    internal class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.EatableFoods = new string[] { "Vegetable", "Fruit", "Meat", "Seeds" };
            this.Growth = 0.35;
        }

        public override string[] EatableFoods { get; set; }
        protected override double Growth { get; set; }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}

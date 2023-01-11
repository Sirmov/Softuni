using System;

namespace _04.WildFarm
{
    internal class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.EatableFoods = new string[] { "Meat" };
            this.Growth = 0.25;
        }

        public override string[] EatableFoods { get; set; }
        protected override double Growth { get; set; }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}

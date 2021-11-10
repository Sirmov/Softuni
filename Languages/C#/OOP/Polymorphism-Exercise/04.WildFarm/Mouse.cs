using System;

namespace _04.WildFarm
{
    internal class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.EatableFoods = new string[] { "Vegetable", "Fruit" };
            this.Growth = 0.10;
        }

        public override string[] EatableFoods { get; set; }
        protected override double Growth { get; set; }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}

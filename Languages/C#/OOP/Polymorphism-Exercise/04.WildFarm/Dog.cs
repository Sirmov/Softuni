using System;

namespace _04.WildFarm
{
    internal class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.EatableFoods = new string[] { "Meat" };
            this.Growth = 0.40;
        }

        public override string[] EatableFoods { get; set; }
        protected override double Growth { get; set; }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}

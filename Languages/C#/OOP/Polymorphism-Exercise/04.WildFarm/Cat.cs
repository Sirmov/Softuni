using System;

namespace _04.WildFarm
{
    internal class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.EatableFoods = new string[] { "Vegetable", "Meat" };
            this.Growth = 0.30;
        }

        public override string[] EatableFoods { get; set; }
        protected override double Growth { get; set; }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}

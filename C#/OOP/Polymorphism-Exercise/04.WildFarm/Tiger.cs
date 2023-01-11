using System;

namespace _04.WildFarm
{
    internal class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.EatableFoods = new string[] { "Meat" };
            this.Growth = 1.00;
        }

        public override string[] EatableFoods { get; set; }
        protected override double Growth { get; set; }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}

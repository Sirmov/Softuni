using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Dog : Animal
    {
        public Dog(string name, string favoriteFood)
            : base(name, favoriteFood) { }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "DJAAF";
        }
    }
}
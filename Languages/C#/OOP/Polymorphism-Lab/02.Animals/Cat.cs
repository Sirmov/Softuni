using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Cat : Animal
    {
        public Cat(string name, string favoriteFood)
            : base(name, favoriteFood) { }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "MEEOW";
        }
    }
}
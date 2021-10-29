using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Fish : MainDish
    {
        private const double Fishgrams = 22;

        public Fish(string name, decimal price)
            : base(name, price, Fishgrams) { }
    }
}

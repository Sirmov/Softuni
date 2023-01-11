using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Cake : Dessert
    {
        private const decimal Cakeprice = 5;
        private const double Cakegrams = 250;
        private const double CakeCalories = 1000;

        public Cake(string name)
            : base(name, Cakeprice, Cakegrams, CakeCalories) { }
    }
}

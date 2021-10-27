using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age) { }

        public override int Age
        {
            get => base.Age;

            set
            {
                //if (value > 15)
                //{
                //    throw new ArgumentException("Children can not be over 15 years old!");
                //}

                base.Age = value;
            }
        }
    }
}

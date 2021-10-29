using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Animal
    {
        private int age;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }

        public int Age
        {
            get => this.age;

            set
            {
                if (value < 0)
                {
                    throw new Exception("Age can not be negative!");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public string Gender { get; set; }

        public virtual string ProduceSound() => null;

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }
    }
}

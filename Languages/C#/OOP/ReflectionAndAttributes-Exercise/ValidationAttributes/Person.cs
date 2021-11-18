using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    internal class Person
    {
        public Person(string fullname, int age)
        {
            this.Fullname = fullname;
            this.Age = age;
        }

        public string Fullname { get; set; }

        public int Age { get; set; }
    }
}

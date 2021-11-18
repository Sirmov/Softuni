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

        [MyRequired]
        public string Fullname { get; set; }

        [MyRange(0, 120)]
        public int Age { get; set; }
    }
}

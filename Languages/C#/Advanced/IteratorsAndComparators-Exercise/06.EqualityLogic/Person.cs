﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _06.EqualityLogic
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        
        public string Name { get; set; }

        public int Age { get; set; }

    }
}

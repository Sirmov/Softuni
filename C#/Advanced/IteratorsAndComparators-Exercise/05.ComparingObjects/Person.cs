using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            int retrieval = 0;

            retrieval = Name.CompareTo(other.Name);

            if (retrieval == 0)
            {
                retrieval = Age.CompareTo(other.Age);
            }

            if (retrieval == 0)
            {
                retrieval = Town.CompareTo(other.Town);
            }

            return retrieval;
        }
    }
}

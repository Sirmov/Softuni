using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var info = Console.ReadLine().Split(", ");
                people.Add(new Person(info[0], int.Parse(info[1])));
            }

            string condition = Console.ReadLine();
            int targetAge = int.Parse(Console.ReadLine());
            Func<Person, bool> filter = f => true;

            if (condition == "younger")
            {
                filter = p => p.Age < targetAge;
            }
            else if (condition == "older")
            {
                filter = p => p.Age >= targetAge;
            }

            condition = Console.ReadLine();
            Func<Person, string> format = p => null;

            if (condition == "name age")
            {
                format = p => $"{p.Name} - {p.Age}";
            }
            else if (condition == "name")
            {
                format = p => $"{p.Name}";
            }
            else if (condition == "age")
            {
                format = p => $"{p.Age}";
            }

            var filteredFormatedPeople = people.Where(filter).Select(format);
            Console.WriteLine(string.Join(Environment.NewLine, filteredFormatedPeople));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}

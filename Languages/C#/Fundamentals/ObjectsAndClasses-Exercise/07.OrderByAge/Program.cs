using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split();
                string name = inputArgs[0];
                string id = inputArgs[1];
                int age = int.Parse(inputArgs[2]);
                people.Add(new Person(name, id, age));
                input = Console.ReadLine();
            }

            people = people.OrderBy(x => x.Age).ToList();

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }

    class Person
    {
        private string name;
        private string id;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person(string name, string id, int age)
        {
            this.name = name;
            this.id = id;
            this.age = age;
        }

        public override string ToString()
        {
            return $"{name} with ID: {id} is {age} years old.";
        }
    }
}

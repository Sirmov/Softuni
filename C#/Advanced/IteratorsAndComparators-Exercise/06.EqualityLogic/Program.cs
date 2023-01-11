using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> peopleHashSet = new HashSet<Person>();
            SortedSet<Person> peopleSortedSet = new SortedSet<Person>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);

                peopleSortedSet.Add(new Person(name, age));
                peopleHashSet.Add(new Person(name, age));
            }

            Console.WriteLine(peopleSortedSet.Count);
            Console.WriteLine(peopleHashSet.Count);
        }
    }
}

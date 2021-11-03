using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirthable> birthables = new List<IBirthable>();

            while (input != "End")
            {
                string[] tokens = input.Split();
                string objectType = tokens[0];

                if (objectType == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    birthables.Add(citizen);
                }
                else if (objectType == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];
                    Pet pet = new Pet(name, birthdate);
                    birthables.Add(pet);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var birthable in birthables.Where(b => b.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(birthable.Birthdate);
            }
        }
    }
}

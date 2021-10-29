using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string type = input;

                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info[2];

                try
                {
                    Animal animal = CreateAnimal(type, name, age, gender);
                    animals.Add(animal);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal.ToString());
                animal.ProduceSound();
            }
        }

        private static Animal CreateAnimal(string type, string name, int age, string gender)
        {
            Animal animal = null;

            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "TomCat")
            {
                animal = new Tomcat(name, age);
            }

            return animal;
        }
    }
}

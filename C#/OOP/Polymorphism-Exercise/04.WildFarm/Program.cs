using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>(); 

            while (input != "End")
            {
                string[] animalInfo = input.Split();
                Animal animal = AnimalFactory(animalInfo);
                animals.Add(animal);
                animal.ProduceSound();

                string[] vegetableInfo = Console.ReadLine().Split();
                Food food = FoodFactory(vegetableInfo);
                animal.Eat(food);

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private static Food FoodFactory(string[] vegetableInfo)
        {
            string type = vegetableInfo[0];
            int quantity = int.Parse(vegetableInfo[1]);

            if (type == "Vegetable")
            {
                return new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                return new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                return new Seeds(quantity);
            }

            throw new ArgumentException("Food type does not exist.");
        }

        private static Animal AnimalFactory(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalInfo[3]);

                return new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalInfo[3]);

                return new Hen(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                string livingRegion = animalInfo[3];

                return new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                string livingRegion = animalInfo[3];

                return new Dog(name, weight, livingRegion);
            }
            else if (type == "Cat")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];

                return new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];

                return new Tiger(name, weight, livingRegion, breed);
            }

            throw new ArgumentException("Animal type does not exist.");
        }
    }
}

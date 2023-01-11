using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                Pizza pizza = null;

                while (input != "END")
                {
                    string[] info = input.Split();
                    string operation = info[0];

                    if (operation == "Pizza")
                    {
                        string name = info[1];
                        pizza = new Pizza(name);
                    }
                    else if (operation == "Dough")
                    {
                        string flourType = info[1];
                        string bakingTechnique = info[2];
                        double weight = double.Parse(info[3]);

                        Dough dough = new Dough(flourType, bakingTechnique, weight);
                        pizza.Dough = dough;
                    }
                    else if (operation == "Topping")
                    {
                        string type = info[1];
                        double weight = double.Parse(info[2]);

                        Topping topping = new Topping(type, weight);
                        pizza.AddTopping(topping);
                    }

                    input = Console.ReadLine();
                }

                if (pizza.ToppingsCount == 0 || pizza.Dough == null)
                {
                    Console.WriteLine("Number of toppings should be in range [0..10].");
                    Environment.Exit(0);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

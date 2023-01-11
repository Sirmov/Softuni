using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            foreach (var item in peopleInput)
            {
                string[] info = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int money = int.Parse(info[1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person.Name, person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }

            foreach (var item in productsInput)
            {
                string[] info = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int cost = int.Parse(info[1]);

                try
                {
                    Product product = new Product(name, cost);
                    products.Add(product.Name, product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = commandInfo[0];
                string productName = commandInfo[1];

                if (people.ContainsKey(personName) && products.ContainsKey(productName))
                {
                    people[personName].PurchaseProduct(products[productName]);
                }

                command = Console.ReadLine();
            }

            foreach (var item in people)
            {
                if (item.Value.Products.Count == 0)
                {
                    Console.WriteLine($"{item.Key} - Nothing bought");
                    continue;
                }

                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value.Products)}");
            }
        }
    }
}

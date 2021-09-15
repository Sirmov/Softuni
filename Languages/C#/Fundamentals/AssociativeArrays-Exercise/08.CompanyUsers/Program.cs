using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string name = input.Split(" -> ")[0];
                string id = input.Split(" -> ")[1];

                if (!companies.ContainsKey(name))
                {
                    companies.Add(name, new List<string>());
                }

                if (!companies[name].Contains(id))
                {
                    companies[name].Add(id);
                }

                input = Console.ReadLine();
            }

            companies = companies.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);
                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> people = new Dictionary<string, IBuyer>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                if (personInfo.Length >= 4)
                {
                    string id = personInfo[2];
                    string birthdate = personInfo[3];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    people.Add(citizen.Name, citizen);
                }
                else
                {
                    string group = personInfo[2];
                    Rebel rebel = new Rebel(name, age, group);
                    people.Add(rebel.Name, rebel);
                }
            }

            string buyer = Console.ReadLine();

            while (buyer != "End")
            {
                if (people.ContainsKey(buyer))
                {
                    people[buyer].BuyFood();
                }

                buyer = Console.ReadLine();
            }

            Console.WriteLine(people.Sum(p => p.Value.Food));
        }
    }
}

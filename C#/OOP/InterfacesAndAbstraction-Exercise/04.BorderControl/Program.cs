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
            List<IIdentifiable> immigrants = new List<IIdentifiable>();

            while (input != "End")
            {
                string[] immigrantInfo = input.Split();

                if (immigrantInfo.Length >= 3)
                {
                    string name = immigrantInfo[0];
                    int age = int.Parse(immigrantInfo[1]);
                    string id = immigrantInfo[2];
                    immigrants.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = immigrantInfo[0];
                    string id = immigrantInfo[1];
                    immigrants.Add(new Robot(model, id));
                }

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            foreach (var immigrant in immigrants.Where(i => i.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(immigrant.Id);
            }
        }
    }
}

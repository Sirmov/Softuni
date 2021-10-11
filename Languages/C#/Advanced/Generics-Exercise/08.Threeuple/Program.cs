using System;
using System.Linq;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split();
            string name = info[0] + " " + info[1];
            string address = info[2];
            string town = info[3];
            for (int i = 4; i < info.Length; i++)
            {
                town += " " + info[i];
            }
            Threeuple<string, string, string> personAddress = new Threeuple<string, string, string>(name, address, town);
            Console.WriteLine(personAddress.ToString());

            info = Console.ReadLine().Split();
            name = info[0];
            int beerLiters = int.Parse(info[1]);
            bool isDrunk = info[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> personBeer = new Threeuple<string, int, bool>(name, beerLiters, isDrunk);
            Console.WriteLine(personBeer.ToString());

            info = Console.ReadLine().Split();
            name = info[0];
            double balance = double.Parse(info[1]);
            string bank = info[2];
            Threeuple<string, double, string> personBank = new Threeuple<string, double, string>(name, balance, bank);
            Console.WriteLine(personBank.ToString());
        }
    }
}

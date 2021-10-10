using System;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split();
            string name = info[0] + " " + info[1];
            string address = info[2];
            Tuple<string, string> personAddress = new Tuple<string, string>(name, address);
            Console.WriteLine($"{personAddress.Item1} -> {personAddress.Item2}");

            info = Console.ReadLine().Split();
            name = info[0];
            int beerLiters = int.Parse(info[1]);
            Tuple<string, int> personBeer = new Tuple<string, int>(name, beerLiters);
            Console.WriteLine($"{personBeer.Item1} -> {personBeer.Item2}");

            info = Console.ReadLine().Split();
            int item1 = int.Parse(info[0]);
            double item2 = double.Parse(info[1]);
            Tuple<int, double> tuple = new Tuple<int, double>(item1, item2);
            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2}");
        }
    }
}

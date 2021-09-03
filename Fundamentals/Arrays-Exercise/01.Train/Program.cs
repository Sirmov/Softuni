using System;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] train = new int[wagons];
            int sum = 0;

            for (int i = 0; i < wagons; i++)
            {
                train[i] = int.Parse(Console.ReadLine());
                sum += train[i];
            }

            Console.WriteLine(string.Join(' ', train));
            Console.WriteLine(sum);
        }
    }
}

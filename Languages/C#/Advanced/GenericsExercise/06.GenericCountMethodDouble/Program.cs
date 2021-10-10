using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = int.Parse(Console.ReadLine());
            List<Box<double>> elements = new List<Box<double>>();

            for (int i = 0; i < elementsCount; i++)
            {
                elements.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(GreaterCount(elements, elementToCompare));
        }

        static int GreaterCount<T>(List<Box<T>> elements, T element)
            where T : IComparable, IComparable<T>
        {
            int count = 0;

            foreach (var item in elements)
            {
                if (item.Value.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

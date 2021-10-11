using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = int.Parse(Console.ReadLine());
            List<Box<string>> elements = new List<Box<string>>();

            for (int i = 0; i < elementsCount; i++)
            {
                elements.Add(new Box<string>(Console.ReadLine()));
            }

            string elementToCompare = Console.ReadLine();

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

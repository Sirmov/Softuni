using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> arrays = input.Split("|").ToList();
            List<int> output = new List<int>();

            for (int i = arrays.Count - 1; i >= 0; i--)
            {
                string array = arrays[i];
                List<int> numbers = array
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                for (int j = 0; j < numbers.Count; j++)
                {
                    output.Add(numbers[j]);
                }
            }
            

            for (int i = 0; i < output.Count; i++)
            {
                Console.Write(output[i] + " ");
            }
        }
    }
}

using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxLenght = int.MinValue;
            int lenght = 1;
            string num = String.Empty;

            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i] == arr[i - 1])
                {
                    lenght++;
                    if (lenght >= maxLenght)
                    {
                        maxLenght = lenght;
                        num = arr[i].ToString();
                    }
                }
                else
                {
                    lenght = 1;
                }

            }

            for (int i = 0; i < maxLenght; i++)
            {
                Console.Write(int.Parse(num) + " ");
            }
        }
    }
}

using System;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                    int count = 0;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        count++;
                    }

                    if (count == arr.Length - (i + 1))
                    {
                        Console.Write(arr[i] + " ");
                    }
                }
            }

            Console.Write(arr[arr.Length - 1] + " ");
        }
    }
}

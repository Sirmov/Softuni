using System;
using System.Linq;

namespace _06.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool isEqual = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int left = 0;
                int right = 0;

                for (int j = i - 1; j >= 0; j--)
                {
                    left += arr[j];
                }

                for (int k = i + 1; k < arr.Length; k++)
                {
                    right += arr[k];
                }

                if (left == right)
                {
                    isEqual = true;
                    Console.WriteLine(i);
                    break;
                }
            }

            if (!isEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}


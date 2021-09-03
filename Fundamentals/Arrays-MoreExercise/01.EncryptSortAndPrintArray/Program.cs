using System;
using System.Linq;

namespace _01.EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = new string[n];

            for (int i = 0; i < n; i++)
            {
                input[i] = Console.ReadLine();
            }

            int[] output = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < input[j].Length; k++)
                    {
                        char curr = (input[j])[k];
                        bool isVowel = "aeiouAEIOU".IndexOf(curr) >= 0;

                        if (isVowel)
                        {
                            sum += (int)curr * input[j].Length;
                        }
                        else
                        {
                            sum += (int)curr / input[j].Length;
                        }
                    }
                    output[j] = sum;
                }
            }

            Array.Sort(output);

            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}

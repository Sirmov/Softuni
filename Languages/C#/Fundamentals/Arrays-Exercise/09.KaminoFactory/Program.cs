using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());

            int length = 1;
            int currMaxLength = int.MinValue;
            int maxLength = int.MinValue;

            int startingIndex = 0;
            int bestStartingIndex = int.MaxValue;

            int maxSum = 0;
            int[] bestDnaSample = new int[len];

            int sequenceIndex = 0;
            int bestSequenceIndex = 0;

            string input = Console.ReadLine();
            while (input != "Clone them!")
            {
                int[] currentArr = input.Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sequenceIndex++;
                int sum = currentArr.Sum();

                for (int i = 0; i < currentArr.Length - 1; i++)
                {
                    if (currentArr[i] == 1 && currentArr[i + 1] == 1)
                    {
                        length++;
                        startingIndex = string.Join("", currentArr).IndexOf(new string('1', length));

                        if (length > currMaxLength)
                        {
                            currMaxLength = length;
                            bestStartingIndex = startingIndex;
                        }
                    }
                    else
                    {
                        length = 1;
                    }

                }

                if (currMaxLength >= maxLength && startingIndex < bestStartingIndex)
                {
                    bestStartingIndex = startingIndex;
                    maxSum = sum;
                    bestDnaSample = currentArr;
                    bestSequenceIndex = sequenceIndex;
                }
                if (currMaxLength >= maxLength && startingIndex == bestStartingIndex && sum > maxSum)
                {
                    maxSum = sum;
                    bestDnaSample = currentArr;
                    bestSequenceIndex = sequenceIndex;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {maxSum}.");
            Console.WriteLine(string.Join(" ", bestDnaSample));
        }
    }
}

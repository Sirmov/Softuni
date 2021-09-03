using System;
using System.Linq;

namespace _04.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sideLenght = integers.Length / 4;
            int[] left = new int[sideLenght];
            int[] right = new int[sideLenght];

            for (int i = 0; i < sideLenght; i++)
            {
                left[i] = integers[i];
                right[i] = integers[integers.Length - 1 - i];
            }

            left = left.Reverse().ToArray();
            int[] firstRow = new int[sideLenght * 2];
            for (int i = 0; i < left.Length; i++)
            {
                firstRow[i] = left[i];
            }
            int j = 0;
            for (int i = left.Length; i < firstRow.Length; i++)
            {
                firstRow[i] = right[j];
                j++;
            }

            int[] secondRow = new int[sideLenght * 2];
            for (int i = 0; i < secondRow.Length; i++)
            {
                secondRow[i] = integers[sideLenght + i];
            }

            int[] result = new int[sideLenght * 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = firstRow[i] + secondRow[i];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

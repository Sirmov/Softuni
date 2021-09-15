using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int elementsToPush = inputArgs[0];
            int elementsToPop = inputArgs[1];
            int elementsToLookFor = inputArgs[2];
            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(elementsToPush);

            for (int i = 0; i < elements.Length; i++)
            {
                stack.Push(elements[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                int min = int.MaxValue;
                bool isFound = false;

                while (stack.Count > 0)
                {
                    if (stack.Peek() == elementsToLookFor)
                    {
                        Console.WriteLine("true");
                        isFound = true;
                        break;
                    }
                    else
                    {
                        if (stack.Peek() < min)
                        {
                            min = stack.Peek();
                        }

                        stack.Pop();
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine(min);
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}

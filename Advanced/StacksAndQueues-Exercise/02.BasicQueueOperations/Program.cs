using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();
            int elementsToEnqueue = inputArgs[0];
            int elementsToDequeue = inputArgs[1];
            int elementsToLookFor = inputArgs[2];
            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(elementsToEnqueue);

            for (int i = 0; i < elements.Length; i++)
            {
                queue.Enqueue(elements[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count > 0)
            {
                int min = int.MaxValue;
                bool isFound = false;

                while (queue.Count > 0)
                {
                    if (queue.Peek() == elementsToLookFor)
                    {
                        Console.WriteLine("true");
                        isFound = true;
                        break;
                    }
                    else
                    {
                        if (queue.Peek() < min)
                        {
                            min = queue.Peek();
                        }

                        queue.Dequeue();
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

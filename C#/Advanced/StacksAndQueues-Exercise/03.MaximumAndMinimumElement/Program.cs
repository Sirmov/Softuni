using System;
using System.Collections.Generic;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int queriesCount = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < queriesCount; i++)
            {
                string[] queryArgs = Console.ReadLine().Split();
                int operation = int.Parse(queryArgs[0]);

                if (operation == 1)
                {
                    int element = int.Parse(queryArgs[1]);
                    stack.Push(element);
                }
                else if (operation == 2)
                {
                    stack.Pop();
                }
                else if (operation == 3)
                {
                    if (stack.Count > 0)
                    {
                        int max = int.MinValue;
                        Stack<int> temp = new Stack<int>(stack);

                        while (temp.Count > 0)
                        {
                            if (temp.Peek() > max)
                            {
                                max = temp.Peek();
                            }

                            temp.Pop();
                        }

                        Console.WriteLine(max);
                    }
                }
                else if (operation == 4)
                {
                    if (stack.Count > 0)
                    {
                        int min = int.MaxValue;
                        Stack<int> temp = new Stack<int>(stack);

                        while (temp.Count > 0)
                        {
                            if (temp.Peek() < min)
                            {
                                min = temp.Peek();
                            }

                            temp.Pop();
                        }

                        Console.WriteLine(min);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}

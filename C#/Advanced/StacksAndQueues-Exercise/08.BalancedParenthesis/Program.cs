using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string parenthesis = Console.ReadLine();
            int opening = 0;
            int closing = 0;
            Stack<char> openedParenthesis = new Stack<char>();

            for (int i = 0; i < parenthesis.Length; i++)
            {
                bool isOpenenig = parenthesis[i] == '(' || parenthesis[i] == '[' || parenthesis[i] == '{';
                bool isClosing = parenthesis[i] == ')' || parenthesis[i] == ']' || parenthesis[i] == '}';

                if (isOpenenig)
                {
                    openedParenthesis.Push(parenthesis[i]);
                    opening++;
                }
                else if (isClosing)
                {
                    if (openedParenthesis.Count > 0)
                    {
                        switch (parenthesis[i])
                        {
                            case ')':
                                if (openedParenthesis.Peek() == '(')
                                {
                                    openedParenthesis.Pop();
                                }
                                break;
                            case ']':
                                if (openedParenthesis.Peek() == '[')
                                {
                                    openedParenthesis.Pop();
                                }
                                break;
                            case '}':
                                if (openedParenthesis.Peek() == '{')
                                {
                                    openedParenthesis.Pop();
                                }
                                break;
                        }
                    }

                    closing++;
                }
            }

            if (openedParenthesis.Count == 0 && opening == closing)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}

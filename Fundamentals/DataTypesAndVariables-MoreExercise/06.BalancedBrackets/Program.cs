using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long openCount = 0;
            long closeCount = 0;

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    openCount++;

                }
                else if (input == ")")
                {
                    closeCount++;
                    if (openCount - closeCount != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
            }
            if (openCount == closeCount)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }

            //int lines = int.Parse(Console.ReadLine());

            //bool isOppened = false;
            //bool isClosed = false;
            //bool isBalanced = false;

            //for (int i = 0; i < lines; i++)
            //{
            //    string input = Console.ReadLine();
            //    if (input == "(" && isOppened)
            //    {
            //        isBalanced = false;
            //    }
            //    else if (input == "(")
            //    {
            //        isOppened = true;
            //        isClosed = false;
            //        isBalanced = false;
            //    }
            //    else if (input == ")" && isClosed)
            //    {
            //        isBalanced = false;
            //        isOppened = true;
            //    }
            //    else if (input == ")" && isOppened)
            //    {
            //        isClosed = true;
            //        isOppened = false;
            //        isBalanced = true;
            //    }
            //}

            //if (isBalanced)
            //{
            //    Console.WriteLine("BALANCED");
            //}
            //else
            //{
            //    Console.WriteLine("UNBALANCED");
            //}
        }
    }
}

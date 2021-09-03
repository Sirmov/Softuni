using System;
using System.Linq;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string reversedStr = string.Join("", str.Reverse()).ToString();
            Console.WriteLine(reversedStr);
        }
    }
}

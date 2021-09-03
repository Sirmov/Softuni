using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            string currentBook = Console.ReadLine();;
            int books = 0;
            while (currentBook != "No More Books")
            {
                if (currentBook == book)
                {
                    Console.WriteLine($"You checked {books} books and found it.");
                    return;
                }
                books++;
                currentBook = Console.ReadLine();
            }
            Console.WriteLine("The book you search is not here!");
            Console.WriteLine($"You checked {books} books.");
        }
    }
}

using System;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] commandArgs = command.Split(":|:");
                string operation = commandArgs[0];

                if (operation == "InsertSpace")
                {
                    int index = int.Parse(commandArgs[1]);
                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }
                else if (operation == "Reverse")
                {
                    string substring = commandArgs[1];
                    char[] arr = substring.ToCharArray();
                    Array.Reverse(arr);
                    string reversed = new string (arr);

                    if (message.Contains(substring))
                    {
                        message = message.Remove(message.IndexOf(substring), substring.Length).ToString();
                        message = message.Insert(message.Length, reversed);

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (operation == "ChangeAll")
                {
                    string substring = commandArgs[1];
                    string replacement = commandArgs[2];
                    message = message.Replace(substring, replacement);

                    Console.WriteLine(message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}

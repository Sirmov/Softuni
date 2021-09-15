using System;
using System.Text;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] commandArgs = command.Split();
                string operation = commandArgs[0];

                if (operation == "TakeOdd")
                {
                    StringBuilder raw = new StringBuilder();

                    for (int i = 0; i < input.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            raw.Append(input[i]);
                        }
                    }
                    
                    input = raw.ToString();
                    Console.WriteLine(raw);
                }
                else if (operation == "Cut")
                {
                    int index = int.Parse(commandArgs[1]);
                    int length = int.Parse(commandArgs[2]);

                    input = input.Remove(index, length);

                    Console.WriteLine(input);
                }
                else if (operation == "Substitute")
                {
                    string oldString = commandArgs[1];
                    string newString = commandArgs[2];
                    
                    if (input.Contains(oldString))
                    {
                        input = input.Replace(oldString, newString);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {input}");
        }
    }
}

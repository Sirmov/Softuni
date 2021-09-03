using System;
using System.Text;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] commandArgs = command.Split("|");
                string operation = commandArgs[0];

                if (operation == "Move")
                {
                    int count = int.Parse(commandArgs[1]);

                    for (int i = 0; i < count; i++)
                    {
                        input.Append(input[0]);
                        input.Remove(0, 1);
                    }
                }
                else if (operation == "Insert")
                {
                    int index = int.Parse(commandArgs[1]);
                    string value = commandArgs[2];
                    input.Insert(index, value);
                }
                else if (operation == "ChangeAll")
                {
                    string substring = commandArgs[1];
                    string replacement = commandArgs[2];

                    input.Replace(substring, replacement);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}
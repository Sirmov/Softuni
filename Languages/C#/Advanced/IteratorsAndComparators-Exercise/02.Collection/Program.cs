using System;
using System.Linq;

namespace _02.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] commandArgs = command.Split();
            var iterator = new ListyIterator<string>(commandArgs.Skip(1).ToArray());

            command = Console.ReadLine();
            while (command != "END")
            {
                commandArgs = command.Split();
                string operation = commandArgs[0];

                if (operation == "Move")
                {
                    Console.WriteLine(iterator.Move());
                }
                else if (operation == "Print")
                {
                    try
                    {
                        iterator.Print();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (operation == "HasNext")
                {
                    Console.WriteLine(iterator.HasNext());
                }
                else if (operation == "PrintAll")
                {
                    iterator.PrintAll();
                }

                command = Console.ReadLine();
            }
        }
    }
}

using System;
using System.Text;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string raw = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] commandArgs = command.Split(">>>");
                string operation = commandArgs[0];

                if (operation == "Contains")
                {
                    if (raw.Contains(commandArgs[1]))
                    {
                        Console.WriteLine($"{raw} contains {commandArgs[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (operation == "Flip")
                {
                    string type = commandArgs[1];
                    int start = int.Parse(commandArgs[2]);
                    int end = int.Parse(commandArgs[3]);

                    StringBuilder flip = new StringBuilder(raw);

                    for (int i = start; i < end; i++)
                    {
                        if (type == "Upper")
                        {
                            flip[i] = char.ToUpper(flip[i]);
                        }
                        else if (type == "Lower")
                        {
                            flip[i] = char.ToLower(flip[i]);
                        }
                    }

                    raw = flip.ToString();
                    Console.WriteLine(raw);
                }
                else if (operation == "Slice")
                {
                    int start = int.Parse(commandArgs[1]);
                    int end = int.Parse(commandArgs[2]);
                    raw = raw.Remove(start, end - start);
                    Console.WriteLine(raw);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {raw}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                string[] commandArgs = command.Split();
                string operation = commandArgs[0];

                if (operation == "Play")
                {
                    songs.Dequeue();
                }
                else if (operation == "Add")
                {
                    Regex regex = new Regex(@"(Add )(?<song>.+)");
                    string song = regex.Match(command).Groups["song"].Value;
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else if (operation == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}

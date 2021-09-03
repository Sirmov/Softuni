using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Piece> pieces = new List<Piece>(n);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                pieces.Add(new Piece(input[0], input[1], input[2]));
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] commandArgs = command.Split("|");
                string operation = commandArgs[0];

                if (operation == "Add")
                {
                    string name = commandArgs[1];
                    string composer = commandArgs[2];
                    string key = commandArgs[3];

                    if (pieces.Any(x => x.Name == name))
                    {
                        Console.WriteLine($"{name} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(new Piece(name, composer, key));
                        Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
                    }
                }
                else if (operation == "Remove")
                {
                    string name = commandArgs[1];

                    if (pieces.RemoveAll(x => x.Name == name) > 0)
                    {
                        Console.WriteLine($"Successfully removed {name}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                    }
                }
                else if (operation == "ChangeKey")
                {
                    string name = commandArgs[1];
                    string key = commandArgs[2];

                    if (pieces.Any(x => x.Name == name))
                    {
                        pieces = pieces.Select((x) => 
                        {
                            if (x.Name == name)
                            {
                                x.Key = key;
                            };
                            return x;
                        }).ToList();

                        Console.WriteLine($"Changed the key of {name} to {key}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in pieces.OrderBy(x => x.Name).ThenBy(x => x.Composer))
            {
                Console.WriteLine($"{item.Name} -> Composer: {item.Composer}, Key: {item.Key}");
            }
        }
    }

    class Piece
    {
        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfs = new List<Dwarf>();
            string input = Console.ReadLine();

            while (input != "Once upon a time")
            {
                string name = input.Split(" <:> ")[0];
                string color = input.Split(" <:> ")[1];
                int physics = int.Parse(input.Split(" <:> ")[2]);
                Dwarf dwarf = new Dwarf(name, color, physics);

                if (dwarfs.Any(x => x.Name == dwarf.Name && x.Color == dwarf.Color))
                {
                    if(dwarfs.Find(x => x.Name == dwarf.Name).Physics < dwarf.Physics)
                    {
                        dwarfs.Find(x => x.Name == dwarf.Name).Physics = dwarf.Physics;
                    }
                   
                }
                else if (dwarfs.Any(x => x.Name == dwarf.Name && x.Color != dwarf.Color))
                {
                    dwarfs.Add(dwarf);
                }
                else
                {
                    dwarfs.Add(dwarf);
                }

                //foreach (var item in dwarfs)
                //{
                //    item.SameHats = dwarfs.Where(y => y.Color == item.Color).Count();
                //}
                
                dwarfs = dwarfs.Select(x => { 
                    x.SameHats = dwarfs.Where(y => y.Color == x.Color).Count();
                    return x;}).ToList();

                input = Console.ReadLine();
            }

            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Physics).ThenByDescending(x => x.SameHats))
            {
                Console.WriteLine(dwarf.ToString());
            }
        }
    }

    class Dwarf
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Physics { get; set; }
        public int SameHats { get; set; }

        public Dwarf(string name, string color, int physics)
        {
            Name = name;
            Color = color;
            Physics = physics;
            SameHats = 0;
        }

        public override string ToString()
        {
            return $"({Color}) {Name} <-> {Physics}";
        }
    }
}

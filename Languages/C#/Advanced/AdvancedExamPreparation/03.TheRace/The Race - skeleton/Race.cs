using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private Dictionary<string, Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new Dictionary<string, Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Racer racer)
        {
            if (Count < Capacity)
            {
                data.Add(racer.Name, racer);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(name);
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(r => r.Value.Age).FirstOrDefault().Value;
        }

        public Racer GetRacer(string name)
        {
            if (data.ContainsKey(name))
            {
                return data[name];
            }

            return null;
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(r => r.Value.Car.Speed).FirstOrDefault().Value;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in data)
            {
                sb.AppendLine(racer.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    class SkiRental
    {
        private List<Ski> skis;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            skis = new List<Ski>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => skis.Count;

        public void Add(Ski ski)
        {
            if (Count < Capacity)
            {
                skis.Add(ski);
            }
        }


        public bool Remove(string manufacturer, string model)
        {
            if (skis.RemoveAll(s => s.Manufacturer == manufacturer && s.Model == model) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Ski GetNewestSki()
        {
            return skis.OrderByDescending(s => s.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return skis.Find(s => s.Manufacturer == manufacturer && s.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in skis)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

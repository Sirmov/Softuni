using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    class Bakery
    {
        private Dictionary<string, Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new Dictionary<string, Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Employee employee)
        {
            if (Count < Capacity && !data.ContainsKey(employee.Name))
            {
                data.Add(employee.Name, employee);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(name);
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Value.Age).FirstOrDefault().Value;
        }

        public Employee GetEmployee(string name)
        {
            if (data.ContainsKey(name))
            {
                return data[name];
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in data)
            {
                sb.AppendLine(employee.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

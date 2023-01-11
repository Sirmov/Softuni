using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> relatives;

        public Family()
        {
            Relatives = new List<Person>();
        }

        public List<Person> Relatives { get { return relatives; } set { relatives = value; } }

        public void AddMember(Person member)
        {
            Relatives.Add(member);
        }

        public Person GetOldestMember()
        {
            return Relatives.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}

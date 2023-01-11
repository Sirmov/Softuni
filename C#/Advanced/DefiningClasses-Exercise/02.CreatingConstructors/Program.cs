using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.Name = "Peter";
            person1.Age = 20;

            Person person2 = new Person { Name = "George", Age = 18 };

            Person person3 = new Person("Jose", 43);
        }
    }
}

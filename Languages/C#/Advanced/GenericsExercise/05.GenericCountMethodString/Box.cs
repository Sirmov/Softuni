using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    class Box<T>
    {
        public Box(T item)
        {
            Value = item;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }
    }
}

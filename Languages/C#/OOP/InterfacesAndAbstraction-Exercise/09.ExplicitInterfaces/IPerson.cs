﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    internal interface IPerson
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string GetName();
    }
}

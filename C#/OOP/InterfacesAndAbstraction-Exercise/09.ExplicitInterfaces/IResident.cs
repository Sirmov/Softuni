﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    internal interface IResident
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string GetName();
    }
}

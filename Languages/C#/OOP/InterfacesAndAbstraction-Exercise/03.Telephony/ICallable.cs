using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    internal interface ICallable
    {
        public void Call(string phoneNumber);
    }
}
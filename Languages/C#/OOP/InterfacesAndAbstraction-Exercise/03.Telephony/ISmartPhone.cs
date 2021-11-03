using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    interface ISmartPhone
    {
        string Call(string phoneNumber);

        string Browse(string website);
    }
}

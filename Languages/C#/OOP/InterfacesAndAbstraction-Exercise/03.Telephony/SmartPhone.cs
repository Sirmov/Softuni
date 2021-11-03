using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    class SmartPhone : ISmartPhone
    {
        public string Browse(string website)
        {
            bool isValid = true;

            foreach (var ch in website)
            {
                if (char.IsDigit(ch))
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                return $"Browsing: {website}!";
            }

            return "Invalid URL!";
        }

        public string Call(string phoneNumber)
        {
            bool isValid = true;

            foreach (var ch in phoneNumber)
            {
                if (!char.IsDigit(ch))
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                return $"Calling... {phoneNumber}";
            }

            return "Invalid number!";
        }
    }
}

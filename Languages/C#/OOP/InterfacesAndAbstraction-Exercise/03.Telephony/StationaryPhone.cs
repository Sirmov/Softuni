using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    class StationaryPhone : IStationaryPhone
    {
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
                return $"Dialing... {phoneNumber}";
            }

            return "Invalid number!";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    static internal class Validator
    {
        public static bool IsValid(object obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                foreach (MyValidationAttribute attr in prop.GetCustomAttributes(typeof(MyValidationAttribute), true))
                {
                    bool isValid = attr.IsValid(prop.GetValue(obj));

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

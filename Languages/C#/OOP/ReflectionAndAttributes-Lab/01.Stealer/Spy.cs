using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {className}");

            Type type = Type.GetType(className);

            var instace = Activator.CreateInstance(type);

            foreach (var field in fieldNames)
            {
                var fieldInfo = type.GetField(field,
                    BindingFlags.Public | BindingFlags.NonPublic |
                    BindingFlags.Instance | BindingFlags.Static);

                if (fieldInfo != null)
                {
                    sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(instace)}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

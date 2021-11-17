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

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);

            foreach (var field in type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static))
            {
                if (!field.IsPrivate)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            foreach (var prop in type.GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static))
            {
                var getMethod = prop.GetGetMethod(true);
                var setMethod = prop.GetSetMethod(true);

                if (!getMethod.IsPublic)
                {
                    sb.AppendLine($"{getMethod.Name} have to be public!");
                }

                if (!setMethod.IsPrivate)
                {
                    sb.AppendLine($"{setMethod.Name} have to be private!");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

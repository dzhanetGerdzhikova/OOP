using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            //bool result = true;

            foreach (var prop in properties)
            {
                var attributes = prop.GetCustomAttributes<MyValidationAttribute>();
                 
                foreach (var atr in attributes)
                {
                    if (!atr.IsValid(prop.GetValue(obj)))
                    {
                        return false;
                    }
                    //result = result & atr.IsValid(prop);
                }
            }

            return true;
        }
    }
}

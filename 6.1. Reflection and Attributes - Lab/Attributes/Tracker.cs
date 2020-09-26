using System;
using System.Linq;
using System.Reflection;

namespace AuthorAttribute
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type typeClass = typeof(StartUp);
            MethodInfo[] methods = typeClass.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(atr => atr.AttributeType.Name == nameof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
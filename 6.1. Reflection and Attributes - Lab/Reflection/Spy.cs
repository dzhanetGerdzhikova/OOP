using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ReflectionExcercises
{
    public class Spy
    {
        //public string StealFieldInfo(string nameOfClass, params string[] nameOfFields)
        //{
        //    Type type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == nameOfClass).FirstOrDefault();
        //    Type typeOfClass = Type.GetType($"{nameof(ReflectionExcercises)}.{nameOfClass}");
        //    FieldInfo[] fieldsOfClass = typeOfClass.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        //    var createdInstance = Activator.CreateInstance(type);
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"Class under investigation: {nameOfClass}");
        //    foreach (var fieldName in nameOfFields)
        //    {
        //        FieldInfo field = fieldsOfClass.Single(e => e.Name == fieldName);
        //        var fieldValue = field.GetValue(createdInstance);
        //        sb.AppendLine($"{fieldName} = {fieldValue}");
        //    }

        //    return sb.ToString().TrimEnd();
        //}
      // public string  AnalyzeAcessModifiers(string nameOfClass)
        //{
        //    Type typeOfClass = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == nameOfClass).FirstOrDefault();
        //    FieldInfo[] fieldsOfClass = typeOfClass.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        //    MethodInfo[] getters = typeOfClass.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        //    MethodInfo[] setters = typeOfClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        //    StringBuilder sb = new StringBuilder();

        //    foreach (var currField in fieldsOfClass)
        //    {
        //        sb.AppendLine($"{ currField.Name} must be private!");
        //    }
        //    foreach (var set in setters.Where(s=>s.Name.StartsWith("get")))
        //    {
        //        sb.AppendLine($"{set.Name} have to be public!");
        //    }
        //    foreach (var get in getters.Where(g=>g.Name.StartsWith("set")))
        //    {
        //        sb.AppendLine($"{get.Name} have to be private!");
        //    }
        //    return sb.ToString().TrimEnd();
       // }

        //public string RevealPrivateMethods(string nameOfClass)
        //{
        //    Type typeOfClass = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == nameOfClass).FirstOrDefault();
        //    MethodInfo[] methodsOfClass = typeOfClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"All Private Methods of Class: {nameOfClass}");
        //    sb.AppendLine($"Base Class: {typeOfClass.BaseType}");
        //    foreach (var method in methodsOfClass)
        //    {
        //        sb.AppendLine(method.Name); 
        //    }
        //    return sb.ToString().TrimEnd();
        //}

        public string CollectGettersAndSetters(string nameOfClass)
        {
            Type typeOfClass = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == nameOfClass).FirstOrDefault();
            MethodInfo[] getters = typeOfClass.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            foreach (var get in getters.Where(g=>g.Name.StartsWith("get")))
            {
                sb.AppendLine($"{get.Name} will return {get.ReturnType}");
            }

            MethodInfo[] setters = typeOfClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var set in setters.Where(s=>s.Name.StartsWith("set")))
            {
                sb.AppendLine($"{set.Name} will set field of {set.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
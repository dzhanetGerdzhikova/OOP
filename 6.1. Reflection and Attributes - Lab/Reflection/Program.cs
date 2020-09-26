using System;

namespace ReflectionExcercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //Spy spy = new Spy();
            //string result = spy.StealFieldInfo("Hacker", "username", "password");
            //Console.WriteLine(result);

            //Spy spy = new Spy();
            //string result = spy.AnalyzeAcessModifiers("Hacker");
            //Console.WriteLine(result);

            //Spy spy = new Spy();
            //string result = spy.RevealPrivateMethods("Hacker");
            //Console.WriteLine(result);

            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}

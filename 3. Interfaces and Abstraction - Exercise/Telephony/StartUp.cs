using System;
using System.Collections.Generic;
using System.Linq;
namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SmartPhone phone = new SmartPhone();
            List<string> numberInfo = Console.ReadLine().Split().ToList();
            List<string> webInfo = Console.ReadLine().Split().ToList();
            foreach (var number in numberInfo)
            {
                if (!number.Any(char.IsLetter))
                {
                    phone.CallTo(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var site in webInfo)
            {
                if (!site.Any(char.IsDigit))
                {
                    phone.BrowsingInWeb(site);

                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
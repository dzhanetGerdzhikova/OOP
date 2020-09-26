using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class SmartPhone : ICalling,IBrowsing
    {
        public void BrowsingInWeb(string webSite)
        {
            if(Validator.IsValidWebSite(webSite))
            {
                Console.WriteLine($"Browsing: {webSite}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }

        public void CallTo(string number)
        {
           if(Validator.IsValidNumber(number))
            {
                Console.WriteLine($"Calling... {number}");
            }
           else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}

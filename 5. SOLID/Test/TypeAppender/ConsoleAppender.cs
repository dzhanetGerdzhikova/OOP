using System;
using System.Collections.Generic;
using System.Text;
using SOLID.Enums;
using SOLID.TypeFormating;

namespace SOLID.TypeAppender
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(IFormating typeFormat)
            :base (typeFormat)
        {
        }

        public override void Append(string dateTime, TypeCommands command, string message)
        {
            if (command >=  this.Command)
            {
                this.Counter++;
                Console.WriteLine(this.TypeFormat.TypeFormat, dateTime, command, message);
            }
        }
       
    }
}

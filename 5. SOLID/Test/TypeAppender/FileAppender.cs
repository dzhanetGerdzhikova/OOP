using System;
using System.Collections.Generic;
using System.Text;
using SOLID.Enums;
using SOLID.LogFile;
using SOLID.TypeFormating;

namespace SOLID.TypeAppender
{
    public class FileAppender : Appender
    {
        public FileAppender(IFormating typeFormat,IFile typeFile)
            :base(typeFormat)
        {
            this.TypeFile = typeFile;
        }
       public  IFile TypeFile { get; }
        public override void Append(string dateTime, TypeCommands command, string message)
        {
            if (command >= this.Command)
            {
                this.Counter++;
                this.TypeFile.Write(string.Format(this.TypeFormat.TypeFormat, dateTime, command, message));
            }
        }
        public override string ToString()
        {
            return base.ToString() +$", File size: {this.TypeFile.Size}";
        }
    }
}

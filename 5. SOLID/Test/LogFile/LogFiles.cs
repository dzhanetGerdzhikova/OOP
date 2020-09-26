using System;
using System.IO;
using System.Linq;

namespace SOLID.LogFile
{
    public class LogFiles : IFile
    {
        private const string FilePath = "../../../log.txt";
       
        public int Size => File.ReadAllText(FilePath).Where(char.IsLetter).Sum(x => x);

        public void Write(string message)
        {
            File.AppendAllText(FilePath, message + Environment.NewLine);
        }
    }
}
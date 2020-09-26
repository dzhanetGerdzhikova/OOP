namespace RobotService.IO
{
    using System;
    using System.IO;
    using RobotService.IO.Contracts;

    public class FileWriter : IWriter
    {
        private string fileName = "out.txt";
        public FileWriter()
        {
            using var stream = File.Create(fileName);
        }

        public void Write(string message)
        {
            File.AppendAllText(fileName, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(fileName, message + Environment.NewLine);
        }
    }
}

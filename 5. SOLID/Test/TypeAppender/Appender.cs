using SOLID.Enums;
using SOLID.TypeFormating;

namespace SOLID.TypeAppender
{
    public abstract class Appender : IAppender
    {
        protected Appender(IFormating typeFormat)
        {
            TypeFormat = typeFormat;
        }

        public IFormating TypeFormat { get; set; }

        public TypeCommands Command { get; set; }
        public int Counter { get; set; }
        public abstract void Append(string dateTime, TypeCommands command, string message);
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.TypeFormat.GetType().Name}, Report level: {this.Command.ToString()}, Messages appended: {this.Counter}";
        }

    }
}
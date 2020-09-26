using SOLID.Enums;
using SOLID.TypeFormating;

namespace SOLID.TypeAppender
{
    public interface IAppender
    {
        IFormating TypeFormat { get; }
        public TypeCommands Command { get; set; }

        void Append(string dateTime, TypeCommands command, string message);
    }
}
using SOLID.Enums;
using SOLID.LogFile;
using SOLID.TypeAppender;
using SOLID.TypeFormating;

namespace SOLID.Factory
{
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string typeAppender, IFormating format, TypeCommands command)
        {
            if (typeAppender == nameof(ConsoleAppender))
            {
                return new ConsoleAppender(format);
            }
            else if (typeAppender == nameof(FileAppender))
            {
                return new FileAppender(format, new LogFiles());
            }
            return null;
        }
    }
}
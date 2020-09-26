using SOLID.Core;
using SOLID.LogFile;
using SOLID.Loggers;
using SOLID.TypeAppender;
using SOLID.TypeFormating;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
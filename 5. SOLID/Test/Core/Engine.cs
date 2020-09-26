using System;
using System.Collections.Generic;
using System.Linq;
using SOLID.Enums;
using SOLID.Factory;
using SOLID.Loggers;
using SOLID.TypeAppender;
using SOLID.TypeFormating;

namespace SOLID.Core
{
    public class Engine : IEngine
    {
        List<IAppender> appenders;
        public Engine()
        {
            appenders = new List<IAppender>();
        }
        public void Run()
        {
            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                string[] infoLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string typeAppender = infoLine[0];
                string typeFormat = infoLine[1];
                TypeCommands command = TypeCommands.INFO;
                if (infoLine.Count() > 2)
                {
                    command = Enum.Parse<TypeCommands>(infoLine[2],true);
                }
                IFormating format = FormatingFactory.CreateFormat(typeFormat);
                if(format!=null)
                {
                    IAppender appender = AppenderFactory.CreateAppender(typeAppender, format,command);
                    if(appender!=null)
                    {
                        appenders.Add(appender);
                    }
                }
            }

            string info = Console.ReadLine();
            ILogger currentLogger = new Logger(appenders.ToArray());

            while (info != "END")
            {
                string[] splitedInfo = info.Split('|').ToArray();
                string commandLevel = splitedInfo[0];
                string date = splitedInfo[1];
                string message = splitedInfo[2];

                LoggerFactory.Message(commandLevel, date, message, currentLogger);

                info = Console.ReadLine();
            }

            Console.WriteLine("Logger info");
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }
    }
}
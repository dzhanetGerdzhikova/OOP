using System;
using System.Collections.Generic;
using System.Text;
using SOLID.Loggers;

namespace SOLID.Factory
{
   public static  class LoggerFactory
    {
        public static void Message(string commandLevel,string date, string message,ILogger logger)
        {
            if(commandLevel=="INFO")
            {
                logger.Info(date, message);
            }
            else if(commandLevel == "WARNING")
            {
                logger.Warning(date, message);
            }
            else if (commandLevel == "ERROR")
            {
                logger.Error(date, message);
            }
            else if (commandLevel == "CRITICAL")
            {
                logger.Critical(date, message);
            }
            else if (commandLevel == "FATAL")
            {
                logger.Fatal(date, message);
            }
        }
    }
}

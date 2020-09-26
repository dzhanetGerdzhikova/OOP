using System;
using System.Collections.Generic;
using System.Text;
using SOLID.Enums;
using SOLID.TypeAppender;

namespace SOLID.Loggers
{
  public  interface ILogger
    {
        IAppender[] TypeAppenders { get; set; }
        void Error(string dateTime,  string message);
        void Info(string dateTime, string message);
        void Fatal(string dateTime, string message);
        void Critical(string dateTime, string message);
        void Warning(string dateTime, string message);
    }
}

using System;
using SOLID.Enums;
using SOLID.TypeAppender;

namespace SOLID.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] typeAppenders;

        public Logger(params IAppender[] typeAppendeers)
        {
            this.TypeAppenders = typeAppendeers;
        }

        public IAppender[] TypeAppenders
        {
            get
            {
                return this.typeAppenders;
            }
            set
            {
                if (value == null)
                {
                    new ArgumentNullException(nameof(TypeAppenders), "cannot be null");
                }
                this.typeAppenders = value;
            }
        }

        public void Critical(string dateTime, string message)
        {
            AppendMessage(dateTime, TypeCommands.CRITICAL, message);
        }

        public void Error(string dateTime, string message)
        {
            AppendMessage(dateTime, TypeCommands.ERROR, message);
        }

        public void Fatal(string dateTime, string message)
        {
            AppendMessage(dateTime, TypeCommands.FATAL, message);
        }

        public void Info(string dateTime, string message)
        {
            AppendMessage(dateTime, TypeCommands.INFO, message);
        }
        public void Warning(string dateTime, string message)
        {
            AppendMessage(dateTime, TypeCommands.WARNING, message);
        }

        private void AppendMessage(string dateTime, TypeCommands command, string message)
        {
            foreach (var typeAppender in this.TypeAppenders)
            {
                typeAppender.Append(dateTime, command, message);
            }
        }
    }
}
using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] splitedArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string nameOfCommand = splitedArgs[0] + "Command";
            string[] arguments = splitedArgs.Skip(1).ToArray();

            Type typeOfCommand = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == nameOfCommand);
            ICommand command = (ICommand)Activator.CreateInstance(typeOfCommand);
            return command.Execute(arguments);
        }
    }
}
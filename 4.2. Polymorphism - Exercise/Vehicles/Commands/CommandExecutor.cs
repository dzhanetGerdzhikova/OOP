using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Commands
{
    public class CommandExecutor
    {
        private ICommand _command;
        public CommandExecutor(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}

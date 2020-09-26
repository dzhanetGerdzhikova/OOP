using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Commands
{
    public class DriveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Drive!");
        }
    }
}

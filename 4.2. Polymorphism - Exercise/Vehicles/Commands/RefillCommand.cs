using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Commands
{
    public class RefillCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Refilled tank!");
        }
    }
}

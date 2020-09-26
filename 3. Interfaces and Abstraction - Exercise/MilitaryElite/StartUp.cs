﻿using MilitaryElite.Core;
using System;

namespace MilitaryElite
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
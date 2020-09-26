using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Core
{
   public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input!="End")
            {
                string[] splitedInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
              string result =  commandInterpreter.Read(splitedInput);
                Console.WriteLine(result);
                input = Console.ReadLine();
            }
        }
    }
}

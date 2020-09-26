using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<ISoldier> soldiers;
        public CommandInterpreter()
        {
            this.soldiers = new List<ISoldier>();
        }
        public string Read(string[] args)
        {
            string soldierType = args[0];
            int id =int.Parse( args[1]);
            string firstName = args[2];
            string lastName = args[3];

           if(soldierType=="Private")
            {
                decimal salary = decimal.Parse(args[4]);
                ISoldier soldier = new Private(id, firstName, lastName, salary);
                soldiers.Add(soldier);
            }
            throw new Exception();
        }
    }
}

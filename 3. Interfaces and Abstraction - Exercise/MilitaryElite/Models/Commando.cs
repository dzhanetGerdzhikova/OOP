using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public List<IMission> Missions { get; private set; }

        public Commando(int id,string firstName, string lastName,  decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<IMission>();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary}");
            result.AppendLine($"Corps: {Corps}");
            result.AppendLine($"Missions:");
            result.AppendLine($"{string.Join(Environment.NewLine, Missions)}");
            return result.ToString().TrimEnd();
        }
    }
}
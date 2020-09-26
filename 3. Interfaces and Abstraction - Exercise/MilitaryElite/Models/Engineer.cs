using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<IRepair> Repairs { get; private set; }

        public Engineer(int id,string firstName, string lastName,  decimal salary, Corps corps, List<IRepair> repairs)
            : base(id, firstName, lastName,  salary, corps)
        {
            Repairs = repairs;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary}");
            result.AppendLine($"Corps: {Corps}");
            result.AppendLine($"Repairs");
            result.AppendLine($"{string.Join(Environment.NewLine, Repairs)}");
            return result.ToString().TrimEnd();
        }
    }
}
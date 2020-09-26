using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public Dictionary<int, IPrivate> Privates { get; private set; }

        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary, Dictionary<int, IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Math.Round(Salary, 2)}");
            result.AppendLine($"Privates:");
            result.AppendLine($"{string.Join(Environment.NewLine, Privates.Select(e => e.Value))}");

            return result.ToString().TrimEnd();
        }
    }
}
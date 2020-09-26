using System.Dynamic;
using System.Reflection;
using System.Text;

namespace MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {FirstName} {LastName} Id: {Id}");
            result.AppendLine($"Code Number: {CodeNumber}");

            return result.ToString().TrimEnd();
        }
    }
}
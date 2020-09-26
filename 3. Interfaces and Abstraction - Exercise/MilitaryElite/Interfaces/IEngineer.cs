using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer : ISpecialisedSoldier
    {
        List<IRepair> Repairs { get; }
    }
}
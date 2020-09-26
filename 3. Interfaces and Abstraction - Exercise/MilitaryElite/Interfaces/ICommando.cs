using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando : ISpecialisedSoldier
    {
        List<IMission> Missions { get; }
    }
}
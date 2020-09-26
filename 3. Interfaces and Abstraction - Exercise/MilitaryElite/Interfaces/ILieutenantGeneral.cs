using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        Dictionary<int, IPrivate> Privates { get; }
    }
}
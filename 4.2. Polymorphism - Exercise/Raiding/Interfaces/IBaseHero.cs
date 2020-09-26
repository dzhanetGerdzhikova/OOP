using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Interfaces
{
   public  interface IBaseHero
    {
        string Name { get; set; }
        int Power { get; set; }
        string CastAbility();
    }
}

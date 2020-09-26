using System;

namespace BorderControl
{
    public interface ILivingCreature
    {
        DateTime Birthdate { get; set; }

        string Name { get; set; }
    }
}
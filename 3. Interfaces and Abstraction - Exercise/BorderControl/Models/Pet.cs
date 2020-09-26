using System;

namespace BorderControl
{
    public class Pet : ILivingCreature
    {
        public Pet(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
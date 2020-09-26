using System;

namespace BorderControl
{
    public class Citizen : Creature, ICitizen
    {
        private int food = 0;

        public Citizen(string name, int age, string id, DateTime birthdate) : base(id)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }

        public int Age { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Food { get { return this.food; } set { this.food = value; } }

        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
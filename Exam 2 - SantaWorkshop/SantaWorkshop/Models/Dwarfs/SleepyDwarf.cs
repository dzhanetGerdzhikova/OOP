namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int Initialenergy = 50;

        public SleepyDwarf(string name)
           : base(name, Initialenergy)
        {
        }

        public override void Work()
        {
            this.Energy -= 15;
        }
    }
}
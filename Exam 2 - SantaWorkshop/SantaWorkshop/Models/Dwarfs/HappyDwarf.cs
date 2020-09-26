using SantaWorkshop.Models.Dwarfs.Contracts;

namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf, IDwarf
    {
        private const int InitialEnergy = 100;

        public HappyDwarf(string name)
            : base(name, InitialEnergy)
        {
        }
    }
}
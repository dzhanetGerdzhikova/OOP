using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;

namespace SantaWorkshop.Factory
{
    public static class DwarfFactory
    {
        public static IDwarf CreateDwarf(string dwarfType, string name)
        {
            if (dwarfType == nameof(SleepyDwarf))
            {
                return new SleepyDwarf(name);
            }
            else if (dwarfType == nameof(HappyDwarf))
            {
                return new HappyDwarf(name);
            }
            return null;
        }
    }
}
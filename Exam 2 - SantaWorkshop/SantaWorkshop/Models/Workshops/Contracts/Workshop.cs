using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using System.Linq;

namespace SantaWorkshop.Models.Workshops.Contracts
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Energy > 0 && dwarf.Instruments.Any())
            {
                IInstrument instrument = dwarf.Instruments.First();
                while (dwarf.Energy > 0 && !instrument.IsBroken() && !present.IsDone())
                {
                    dwarf.Work();
                    present.GetCrafted();
                    instrument.Use();
                }
                if (instrument.IsBroken())
                {
                    dwarf.Instruments.Remove(instrument);
                }
                if (present.IsDone())
                {
                    break;
                }
            }
        }
    }
}
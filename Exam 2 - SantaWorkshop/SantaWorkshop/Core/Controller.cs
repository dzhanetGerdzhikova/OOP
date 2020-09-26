using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Factory;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using SantaWorkshop.Repositories.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfsRepo;
        private PresentRepository presentsRepo;

        public Controller()
        {
            this.dwarfsRepo = new DwarfRepository();
            this.presentsRepo = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf currentDwarf = DwarfFactory.CreateDwarf(dwarfType, dwarfName);
            if (currentDwarf != null)
            {
                dwarfsRepo.Add(currentDwarf);
                return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
            }
            return string.Format(ExceptionMessages.InvalidDwarfType);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IInstrument currentInstrument = new Instrument(power);
            IDwarf dwarf = dwarfsRepo.FindByName(dwarfName);
            if (dwarf == null)
            {
                return ExceptionMessages.InexistentDwarf;
            }

            dwarf.AddInstrument(currentInstrument);
            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);
            presentsRepo.Add(present);
            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            Workshop workshop = new Workshop();
            IPresent present = presentsRepo.FindByName(presentName);
           ICollection<IDwarf> dwarves = dwarfsRepo.Models.Where(e => e.Energy >= 50).OrderByDescending(e => e.Energy).ToList();

            if (!dwarves.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }
            while (dwarves.Any())
            {
                IDwarf dwarf = dwarves.First();
                workshop.Craft(present, dwarf);
                if (dwarf.Energy == 0)
                {
                    dwarfsRepo.Remove(dwarf);
                    dwarves.Remove(dwarf);
                }
                if(!dwarf.Instruments.Any())
                {
                    dwarves.Remove(dwarf);
                }
                if(present.IsDone())
                {
                    break;
                }
            }

            if (present.IsDone())
            {
                return string.Format(OutputMessages.PresentIsDone, presentName);
            }
            else
            {
                return string.Format(OutputMessages.PresentIsNotDone, presentName);
            }
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            int readyPresents = presentsRepo.Models.Count(e => e.IsDone());
            result.AppendLine($"{readyPresents} presents are done!");
            result.AppendLine("Dwarfs info:");

            foreach (var dwarf in dwarfsRepo.Models)
            {
                result.AppendLine(dwarf.ToString());
                int leftsinstruments = dwarf.Instruments.Count();
                result.AppendLine($"Instruments: {leftsinstruments} not broken left");
            }
            return result.ToString().TrimEnd();
        }
    }
}
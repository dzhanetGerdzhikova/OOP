using SantaWorkshop.IO.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories.Contracts
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly ICollection<IDwarf> models;
        public DwarfRepository()
        {
            models = new List<IDwarf>();
        }
        public IReadOnlyCollection<IDwarf> Models =>(IReadOnlyCollection<IDwarf>) models;

        public void Add(IDwarf model)
        {
            this.models.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            return this.models.FirstOrDefault(d => d.Name == name);
        }

        public IEnumerable<IDwarf> GetReadyDwarves()
        {
            return this.models.Where(e => e.Energy >= 50);
        }

        public bool Remove(IDwarf model)
        {
            return this.models.Remove(model);
        }
    }
}

using SantaWorkshop.Models.Presents.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SantaWorkshop.Repositories.Contracts
{
    public class PresentRepository : IRepository<IPresent>
    {
        private ICollection<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models =>(IReadOnlyCollection<IPresent>) models;

        public void Add(IPresent model)
        {
            this.models.Add(model);
        }

        public IPresent FindByName(string name)
        {
            return models.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IPresent model)
        {
            return models.Remove(model);
        }
    }
}
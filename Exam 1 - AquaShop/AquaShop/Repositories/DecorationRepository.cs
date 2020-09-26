using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> decorationRepo;
        public IReadOnlyCollection<IDecoration> Models => decorationRepo.ToList().AsReadOnly();

        public DecorationRepository()
        {
            decorationRepo = new List<IDecoration>();
        }
        public void Add(IDecoration model)
        {
            decorationRepo.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return decorationRepo.FirstOrDefault(d => d.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
          return  decorationRepo.Remove(model);
        }
    }
}

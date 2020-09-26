using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;

namespace AquaShop.Factory
{
    public static class AquariumFactory
    {
        public static IAquarium CreateAquarium(string typeAquarium, string name)
        {
            if (typeAquarium == nameof(FreshwaterAquarium))
            {
                return new FreshwaterAquarium(name);
            }
            else if(typeAquarium==nameof(SaltwaterAquarium))
            {
                return new SaltwaterAquarium(name);
            }
            return null;
        }
    }
}
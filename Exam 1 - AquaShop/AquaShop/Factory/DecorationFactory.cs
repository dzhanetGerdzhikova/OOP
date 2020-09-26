using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Factory
{
    public static class DecorationFactory
    {
        public static IDecoration CreateDecoration(string type)
        {
            if (type == nameof(Plant))
            {
                return new Plant();
            }
            else if(type==nameof(Ornament))
            {
                return new Ornament();
            }
            return null;
        }
    }
}
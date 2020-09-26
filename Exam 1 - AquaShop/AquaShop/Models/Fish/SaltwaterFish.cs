using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish, IFish
    {
        private const int initialFishSize = 5;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = initialFishSize;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
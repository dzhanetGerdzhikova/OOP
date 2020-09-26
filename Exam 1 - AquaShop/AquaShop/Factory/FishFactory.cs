using AquaShop.Models.Aquariums;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Factory
{
   public static class FishFactory 
    {
        public static IFish CreateFish(string fishType, string fishName,string fishSpecies, decimal price)
        {
            if(fishType==nameof(FreshwaterFish))
            {
                return new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if(fishType==nameof(SaltwaterFish))
            {
                return new SaltwaterFish(fishName, fishSpecies, price);
            }
            return null;
        }
    }
}

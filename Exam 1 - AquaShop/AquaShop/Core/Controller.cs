using AquaShop.Core.Contracts;
using AquaShop.Factory;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decotarionRepo;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decotarionRepo = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium currentAquarium = AquariumFactory.CreateAquarium(aquariumType, aquariumName);
            if (currentAquarium == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            aquariums.Add(currentAquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration currentDecoration = DecorationFactory.CreateDecoration(decorationType);
            if (currentDecoration == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            decotarionRepo.Add(currentDecoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish currentFish = FishFactory.CreateFish(fishType, fishName, fishSpecies, price);
            if (currentFish == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            string aquariumType = aquarium.GetType().Name.Replace("Aquarium", "");

            if (!fishType.Contains(aquariumType))
            {
                return OutputMessages.UnsuitableWater;
            }
            aquarium.AddFish(currentFish);
            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal sumFish = aquarium.Fish.Select(f => f.Price).Sum();
            decimal sumDecoration = aquarium.Decorations.Select(d => d.Price).Sum();
            decimal totalSum = sumFish + sumDecoration;

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalSum);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            foreach (IFish fish in aquarium)
            {
                fish.Eat();
            }
            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count());
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IDecoration decoration = decotarionRepo.FindByType(decorationType);
            if(decoration==null)
            {
               throw new  InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,decorationType));
            }
            aquarium.Decorations.Add(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                result.AppendLine(aquarium.GetInfo());
            }
            return result.ToString().TrimEnd();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Models.Animal
{
   public  abstract class Feline : Mammal
    {
        public string Breed { get;private set; }
        public Feline(string name, double weight, string livingRegion,string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {EatenFood}]";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Models.Animal
{
    public abstract  class Bird : Animal
    {
        public double WingSize { get; private set; }
        public Bird(string name, double weight,double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.EatenFood}]";
        }
    }
}

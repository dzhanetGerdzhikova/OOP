using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Presents.Contracts
{
   public  class Present : IPresent
    {
        private string name;
        private int energyRequired;
        public Present(string name, int energyrequired)
        {
            this.Name = name;
            this.EnergyRequired = energyrequired;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
           private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return this.energyRequired;
            }
          private  set
            {
                if(value<0)
                {
                    this.energyRequired = 0;
                }
                this.energyRequired = value;
            }
        }
        public void GetCrafted()
        {
            this.EnergyRequired -= 10;
        }

        public bool IsDone()
        {
            if(this.EnergyRequired==0)
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
      public Bus(double consumption, double fuelQuantity, double tankCapacity)
            : base( consumption,  fuelQuantity,  tankCapacity)
        {
            this.Consumption += 1.4;
        }
        public void DriveEmpty(double distance)
        {
            this.Consumption -= 1.4;
            this.Drive(distance);
            this.Consumption += 1.4;
        }
    }
}

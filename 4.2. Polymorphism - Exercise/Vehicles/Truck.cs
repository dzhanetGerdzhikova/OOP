using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double consumption, double fuelQuantity, double tankCapacity) : base(consumption, fuelQuantity, tankCapacity)
        {
            this.Consumption += 1.6;
        }
        public override void Refuel(double litters)
        {
            var newLitters = litters * 0.95;
            if (newLitters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (newLitters + this.FuelQuantity > this.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {litters} fuel in the tank");
                }
                else
                {
                    this.FuelQuantity += newLitters;
                }
            }
        }
    }
}

using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        protected Vehicle(double consumption, double fuelQuantity, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            Consumption = consumption;
            FuelQuantity = fuelQuantity;
        }

        public double Consumption { get; set; }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value <= this.TankCapacity)
                {
                    this.fuelQuantity = value;
                }
                else
                {
                    this.fuelQuantity = 0;
                }
            }
        }

        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            if (distance * this.Consumption <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * this.Consumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double litters)
        {
            if (litters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (litters + this.FuelQuantity > this.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {litters} fuel in the tank");
                }
                else
                {
                    this.FuelQuantity += litters;
                }
            }
        }
    }
}
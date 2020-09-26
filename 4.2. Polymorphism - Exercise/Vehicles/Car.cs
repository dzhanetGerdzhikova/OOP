namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double consumption, double fuelQuantity, double tankCapacity)
            : base(consumption, fuelQuantity, tankCapacity)
        {
            this.Consumption += 0.9;
        }

    }
}
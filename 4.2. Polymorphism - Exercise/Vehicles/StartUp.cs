using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            for (int i = 0; i < 3; i++)
            {
                string[] vehicleInfo = Console.ReadLine().Split();
                double vehicleQuantity = double.Parse(vehicleInfo[1]);
                double vehicleConsumption = double.Parse(vehicleInfo[2]);
                double vehicletankCapacity = double.Parse(vehicleInfo[3]);

                Vehicle vehicle = null;
                if (vehicleInfo[0] == "Car")
                {
                    vehicle = new Car(vehicleConsumption, vehicleQuantity, vehicletankCapacity);
                }
                else if (vehicleInfo[0] == "Truck")
                {
                    vehicle = new Truck(vehicleConsumption, vehicleQuantity, vehicletankCapacity);
                }
                else if (vehicleInfo[0] == "Bus")
                {
                    vehicle = new Bus(vehicleConsumption, vehicleQuantity, vehicletankCapacity);
                }
                vehicles.Add(vehicle);
            }

            int countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {
                string[] info = Console.ReadLine().Split();
                string command = info[0];
                string type = info[1];
                double km = double.Parse(info[2]);
                Vehicle vehicle = vehicles.Single(e => e.GetType().Name == type);

                vehicle.GetType().GetMethod(command).Invoke(vehicle, new object[] { km });
                //vehicle.GetMethod(command).Invoke(km)
                //if (command == "Drive")
                //{
                //    vehicle.Drive(km);
                //}
                //else if (command == "Refuel")
                //{
                //    vehicle.Refuel(km);
                //}
            }
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.GetType().Name}: {Math.Round(vehicle.FuelQuantity, 2):f2}");
            }
        }
    }
}
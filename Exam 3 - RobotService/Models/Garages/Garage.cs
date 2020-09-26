using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        public int Capacity => 10;
        private IDictionary<string, IRobot> robots;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots => robots.ToDictionary(x => x.Key, y => y.Value);

        public void Manufacture(IRobot robot)
        {
            if (this.Capacity < this.robots.Count())
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
            else
            {
                if (robots.ContainsKey(robot.Name))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
                }
                else
                {
                    this.robots.Add(robot.Name, robot);
                }
            }
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, robotName);
            }
            else
            {
                IRobot robot = this.robots[robotName];
                robot.IsBought = true;
                robot.Owner = ownerName;
                this.robots.Remove(robotName);
            }
        }
    }
}
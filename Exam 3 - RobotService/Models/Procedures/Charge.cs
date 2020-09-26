using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedure, IProcedure
    {
        private const int AddHappiness = 12;
        private const int AddEnergy = 10;

        public Charge()
        {
        }

        public override void ManipualateRobotSettings(IRobot robot)
        {
            robot.Happiness += AddHappiness;
            robot.Energy += AddEnergy;
        }
    }
}
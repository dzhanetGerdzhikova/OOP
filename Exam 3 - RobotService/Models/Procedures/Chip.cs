using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure, IProcedure
    {
        private const int RemovedHappiness = 5;

        public Chip()
        {
        }

        public override void ManipualateRobotSettings(IRobot robot)
        {
            robot.Happiness -= RemovedHappiness;

            if (robot.IsChipped)
            {
                throw new ArgumentException(ExceptionMessages.AlreadyChipped, robot.Name);
            }
            robot.IsChipped = true;
        }
       
    }
}
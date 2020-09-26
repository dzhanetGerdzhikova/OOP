using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
   public  class Rest :Procedure, IProcedure
    {
        private const int RemoveHappiness = 3;
        private const int AddEnergy = 10;
        public Rest()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness -= RemoveHappiness;
            robot.Energy += AddEnergy;
            Robots.Add(robot);
            robot.ProcedureTime -= procedureTime;
        }
    }
}

using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
   public  class Polish :Procedure, IProcedure
    {
        private const int RemoveHappiness = 7;
        public Polish()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness -= RemoveHappiness;
            Robots.Add(robot);
            robot.ProcedureTime -= procedureTime;
        }
    }
}

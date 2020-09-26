using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
   public  class Work :Procedure, IProcedure
    {
        private int RemoveEnergy = 6;
        private const int AddHappiness = 12;
        public Work()
        {

        }
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy -= RemoveEnergy;
            robot.Happiness += AddHappiness;
            Robots.Add(robot);
            robot.ProcedureTime -= procedureTime;
        }
    }
}

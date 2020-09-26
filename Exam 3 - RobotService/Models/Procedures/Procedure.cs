using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        protected ICollection<IRobot> Robots { get; }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            ManipualateRobotSettings(robot);

            Robots.Add(robot);
            robot.ProcedureTime -= procedureTime;
        }

        public abstract void ManipualateRobotSettings(IRobot robot);

        public string History()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.GetType().Name}");

            foreach (var robot in this.Robots)
            {
                result.AppendLine(robot.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
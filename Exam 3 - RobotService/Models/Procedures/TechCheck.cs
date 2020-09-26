using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure, IProcedure
    {
        private int RemoveEnergy = 8;

        public TechCheck()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy -= RemoveEnergy;

            if(robot.IsChecked)
            {
                robot.Energy -= RemoveEnergy;
            }
            robot.IsChecked = true;

            Robots.Add(robot);
            robot.ProcedureTime -= procedureTime;
        }
    }
}
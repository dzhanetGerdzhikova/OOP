using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Core.Factory
{
    public static class FactoryRobot
    {
        public static IRobot CreateRobot(string type, string name, int energy, int happiness, int procedureTime)
        {
            if (type == nameof(HouseholdRobot))
            {
                return new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (type == nameof(PetRobot))
            {
                return new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (type == nameof(WalkerRobot))
            {
                return new WalkerRobot(name, energy, happiness, procedureTime);
            }
            return null;
        }
    }
}
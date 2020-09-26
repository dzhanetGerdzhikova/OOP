using RobotService.Core.Contracts;
using RobotService.Core.Factory;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage robotsRepo;
        private ICollection<IProcedure> procedures;

        public Controller()
        {
            robotsRepo = new Garage();
            procedures = new List<IProcedure>
            {
                new Chip(),
                new Polish(),
                new Charge(),
                new Rest(),
                new TechCheck(),
                new Work()
            };
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures.Single(p => p is Charge).DoService(robot, procedureTime);
            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures.Single(e => e is Chip).DoService(robot, procedureTime);
            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            IProcedure procedure = procedures.Single(p => p.GetType().Name == procedureType);
            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = FactoryRobot.CreateRobot(robotType, name, energy, happiness, procedureTime);
            if (robot == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
            robotsRepo.Manufacture(robot);
            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures.Single(p => p is Polish).DoService(robot, procedureTime);
            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures.Single(p => p is Rest).DoService(robot, procedureTime);
            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = GetRobot(robotName);
            robotsRepo.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures.Single(p => p is TechCheck).DoService(robot, procedureTime);
            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        private IRobot GetRobot(string robotName)
        {
            if (!this.robotsRepo.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.robotsRepo.Robots[robotName];
            return robot;
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            procedures.Single(p => p is Work).DoService(robot, procedureTime);
            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }
    }
}
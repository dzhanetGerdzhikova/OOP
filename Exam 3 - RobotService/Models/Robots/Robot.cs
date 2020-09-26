using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }

        public string Name { get;}

        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            set
            {
                this.happiness = value < 0 || value > 100 ? throw new ArgumentException(ExceptionMessages.InvalidHappiness) : value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                this.energy = value < 0 || value > 100 ? throw new ArgumentException(ExceptionMessages.InvalidEnergy) : value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; } = "Service";

        public bool IsBought { get; set; } = false;
        public bool IsChipped { get; set; } = false;
        public bool IsChecked { get; set; } = false;

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
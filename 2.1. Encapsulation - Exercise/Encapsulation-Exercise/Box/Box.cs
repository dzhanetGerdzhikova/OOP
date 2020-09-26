using System;
using System.Text;

namespace Encapsulation_Exercise
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }

        public double SurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double LateralArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            result.AppendLine($"Lateral Surface Area - {this.LateralArea():f2}");
            result.AppendLine($"Volume - {this.Volume():f2}");

            return result.ToString().TrimEnd();
        }
    }
}
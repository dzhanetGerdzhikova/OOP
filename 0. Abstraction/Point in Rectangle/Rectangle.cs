using System;///

namespace PointinRectangle
{
    public class Rectangle
    {
        public Rectangle(Point left, Point right)
        {
            this.TopLeft = left;
            this.BottomRight = right;
        }

        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            bool isVertical = Math.Min(TopLeft.Y, BottomRight.Y) <= point.Y && Math.Max(TopLeft.Y, BottomRight.Y) >= point.Y;
            bool isHorizontal = Math.Min(TopLeft.X, BottomRight.X) <= point.X && Math.Max(TopLeft.X, BottomRight.X) >= point.X;
            return isVertical && isHorizontal;
        }
    }
}
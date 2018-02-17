using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class Rectangle : Shape
	{
		public Point Point1 { get; set; }
		public Point Point2 { get; set; }

		public Rectangle(Point p1, Point p2) : base("RECTANGLE")
		{
			Point1 = p1;
			Point2 = p2;
		}

		public override double GetPerimeter()
		{
			return 2 * (Math.Abs(Point1.X - Point2.X) + Math.Abs(Point1.Y - Point2.Y));
		}

		public override double GetSquare()
		{
			return Math.Abs(Point1.X - Point2.X) * Math.Abs(Point1.Y - Point2.Y);
		}
	}
}

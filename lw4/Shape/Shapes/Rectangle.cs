using System;
using System.Collections.Generic;
using System.Text;
using LongMath;

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

		public override BigNumber GetPerimeter()
		{
			return 2 * ((Point1.X - Point2.X) + (Point1.Y - Point2.Y));
		}

		public override BigNumber GetSquare()
		{
			return (Point1.X - Point2.X) * (Point1.Y - Point2.Y);
		}
	}
}

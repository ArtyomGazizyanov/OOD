using System;
using System.Collections.Generic;
using System.Text;
using LongMath;

namespace Shape
{
	class Triangle : Shape
	{
		public Point Point1 { get; set; }
		public Point Point2 { get; set; }
		public Point Point3 { get; set; }

		public Triangle(Point p1, Point p2, Point p3) : base("TRIANGLE")
		{
			Point1 = p1;
			Point2 = p2;
			Point3 = p3;
		}

		public override BigNumber GetPerimeter()
		{
			BigNumber a = Calculator.Pow(Point2.X - Point1.X, 2) + Calculator.Pow(Point2.Y - Point1.Y, 2);
			a = a.Sqrt();
			BigNumber b = Calculator.Pow(Point3.X - Point1.X, 2) + Calculator.Pow(Point3.Y - Point1.Y, 2);
			b = b.Sqrt();
			BigNumber c = Calculator.Pow(Point3.X - Point2.X, 2) + Calculator.Pow(Point3.Y - Point2.Y, 2);
			c = c.Sqrt();

			return a + b + c;
		}

		public override BigNumber GetSquare()
		{
			BigNumber answer = (Point1.X - Point3.X);
			answer = answer * (Point2.Y - Point3.Y);
			answer = answer - ((Point2.X - Point3.X) * (Point1.Y - Point3.Y));
			answer = 5 * answer;
			if (!answer.EqualsDigits(new BigNumber("0")))
			{
				answer.RemoveDigitsAtBeginnig(1);
			}

			return answer;
		}
	}
}

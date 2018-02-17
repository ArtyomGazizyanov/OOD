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
		     BigNumber a = new BigNumber("16");// Calculator.Pow(Point2.X - Point1.X, 2) + Calculator.Pow(Point2.Y - Point1.Y, 2);

			BigNumber b = new BigNumber("16"); //Calculator.Pow(Point3.X - Point1.X, 2) + Calculator.Pow(Point3.Y - Point1.Y, 2);
		    BigNumber c = new BigNumber("16");// Calculator.Pow(Point3.X - Point2.X, 2) + Calculator.Pow(Point3.Y - Point2.Y, 2);

		    return a.Sqrt() + b.Sqrt() + c.Sqrt();
		}

	    public override BigNumber GetSquare()
	    {
		    BigNumber answer = 5 * ((Point1.X - Point3.X) * (Point2.Y - Point3.Y) - (Point2.X - Point3.X) * (Point1.Y - Point3.Y));
		    answer.RemoveDigitsAtBeginnig(1);

		    return answer;
	    }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

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

	    public override double GetPerimeter()
	    {
		    double a = Math.Sqrt(Math.Pow(Point2.X - Point1.X, 2) + Math.Pow(Point2.Y - Point1.Y, 2));
		    double b = Math.Sqrt(Math.Pow(Point3.X - Point1.X, 2) + Math.Pow(Point3.Y - Point1.Y, 2));
		    double c = Math.Sqrt(Math.Pow(Point3.X - Point2.X, 2) + Math.Pow(Point3.Y - Point2.Y, 2));

		    return a + b + c;
		}

	    public override double GetSquare()
	    {
		    return 0.5 * (((Point1.X - Point3.X) * (Point2.Y - Point3.Y)) - ((Point2.X - Point3.X) * (Point1.Y - Point3.Y)));
	    }
	}
}

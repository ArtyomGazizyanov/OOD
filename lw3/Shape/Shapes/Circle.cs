using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class Circle : Shape
    { 
		public Point Point { get; set; }
		public int Radius { get; set; }

	    public Circle(Point p1, int radius) : base("CIRCLE")
	    {
		    Point = p1;
		    Radius = radius;
	    }
	    public override double GetPerimeter()
	    {
		    return 2 * Math.PI * Radius;
	    }

	    public override double GetSquare()
	    {
		    return Math.PI * Math.Pow(Radius, 2);
	    }

    }
}

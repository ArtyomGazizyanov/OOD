using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class Point
    {
	    public int X { get; set; }
	    public int Y { get; set; }

		public Point(int x, int y)
	    {
		    X = x;
		    Y = y;
	    }

	    public Point()
	    {
		    X = 0;
		    Y = 0;
	    }
    }
}

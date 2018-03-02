using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class CircleCreator
    {
	    private static CircleCreator _instance;

	    private CircleCreator()
	    {
	    }

	    public static CircleCreator GetInstance()
	    {
		    return _instance ?? (_instance = new CircleCreator());
	    }

	    public Circle Create(Point point, int radius)
	    {
		    return new Circle(point, radius);
	    }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class TriangleCreator
    {
	    private static TriangleCreator _instance;

	    private TriangleCreator()
	    { }

	    public static TriangleCreator GetInstance()
	    {
		    return _instance ?? (_instance = new TriangleCreator());
	    }

	    public Triangle Create(Point point1, Point point2, Point point3)
	    {
		    return new Triangle(point1, point2, point3);
	    }
	}
}

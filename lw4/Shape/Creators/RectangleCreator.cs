using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class RectangleCreator
    {
	    private static RectangleCreator _instance;

	    private RectangleCreator()
	    { }

	    public static RectangleCreator GetInstance()
	    {
		    return _instance ?? (_instance = new RectangleCreator());
	    }

	    public Rectangle Create(Point point1, Point point2)
	    {
		    return new Rectangle(point1, point2);
	    }
	}
}

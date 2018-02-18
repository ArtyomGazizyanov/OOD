using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shape
{
    class ShapeList : List<Shape>
    {
	    public void Accept(IShapeVisitor visitor)
	    {
		    foreach (Shape el in this)
		    {
				visitor.VisitShape(el);
			}
	    }
    }
}

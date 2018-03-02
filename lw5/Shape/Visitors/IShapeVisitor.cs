using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    public interface IShapeVisitor
    {
	    void VisitShape(Shape shape);
    }
}

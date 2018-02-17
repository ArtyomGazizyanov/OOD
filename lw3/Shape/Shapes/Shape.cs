using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class Shape: IShape
    {
		private string Type { get; }

	    public Shape(string type)
	    {
		    this.Type = type;
	    }

	    public virtual string GetName()
	    {
		    return Type;
	    }

	    public virtual double GetPerimeter()
	    {
		    throw new NotImplementedException();
	    }

	    public virtual double GetSquare()
	    {
		    throw new NotImplementedException();
	    }
    }
}

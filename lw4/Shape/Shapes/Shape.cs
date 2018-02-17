using System;
using LongMath;

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

	    public virtual BigNumber GetPerimeter()
	    {
		    throw new NotImplementedException();
	    }

	    public virtual BigNumber GetSquare()
	    {
		    throw new NotImplementedException();
	    }
    }
}

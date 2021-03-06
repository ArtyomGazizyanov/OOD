﻿using LongMath;

namespace Shape
{
    public interface IShape
    {
		string GetName();
	    BigNumber GetPerimeter();
	    BigNumber GetSquare();
	}
}

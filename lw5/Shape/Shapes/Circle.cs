using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LongMath;

namespace Shape
{
    class Circle : Shape
    { 
		public Point Point { get; set; }
		public BigNumber Radius { get; set; }

	    public Circle(Point p1, BigNumber radius) : base("CIRCLE")
	    {
		    Point = p1;
		    Radius = radius;
	    }
	    public override BigNumber GetPerimeter()
	    {  
			BigNumber piNumberBig = Calculator.GetСoercedPiNumber(Radius.Digits.Count);
		    BigNumber answer = 2 * piNumberBig * Radius;
		    answer.RemoveDigitsAtBeginnig(Radius.Digits.Count);

		    return answer;
	    }

	    public override BigNumber GetSquare()
	    {
		    BigNumber radiusInSquare = Calculator.Pow(Radius, 2);
		    BigNumber piNumberBig = Calculator.GetСoercedPiNumber(radiusInSquare.Digits.Count);

			BigNumber answer = piNumberBig * radiusInSquare;
		    answer.RemoveDigitsAtBeginnig(radiusInSquare.Digits.Count);

			return answer;
		}

	    public override void Accept(IShapeVisitor visitor)
	    {
		    
	    }
	}
}

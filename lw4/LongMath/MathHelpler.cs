using System;
using System.Collections.Generic;
using System.Text;

namespace LongMath
{
    public static class MathHelpler
    {
	    public static BigNumber ResolveOperator(string mathOperator, BigNumber left, BigNumber right)
	    {
			switch (mathOperator)
			{
				case "+":
					return left + right;
				case "-":
					return left - right;
				case "/":
					return left / right;
				case "*":
					return left * right;
				default:
					return null;
			}
		}
    }
}

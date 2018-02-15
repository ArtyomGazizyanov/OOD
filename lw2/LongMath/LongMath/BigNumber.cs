using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace LongMath
{
	public class BigNumber
	{
		public List<int> Digits { get; } = new List<int>();
		public bool IsPositive { get; private set; } = true;

		public BigNumber()
		{
		}

		public BigNumber(List<int> digits, bool isPositive = true)
		{
			Digits = digits ?? throw new ArgumentNullException("Parameter shouldn`t be null");
			IsPositive = isPositive;
		}

		public BigNumber(string digitString)
	    {
		    if (digitString == null)
		    {
			    throw new ArgumentNullException("Parameter shouldn`t be null");
		    }

		    var reversedString = digitString.Reverse().ToList();
			    

			foreach (var digit in reversedString)
		    {
			    if (!Char.IsDigit(digit))
			    {
				    if (!IsSign(digit))
				    {
					    throw new ArgumentException("Number contains invalid symbols");
					}
				    SetSigne(digit);
			    }

			    Digits.Add(ConvertCharToDigit(digit));
		    }
	    }

		public override string ToString()
		{
			List<int> digitCopy = Digits;
			digitCopy.Reverse();
			string resultString = String.Empty;
			foreach (var digit in digitCopy)
			{
				resultString += digit;
			}
			
			return resultString;
		}

		public static BigNumber operator +(BigNumber number1, BigNumber number2)
		{
			return Calculator.Plus(number1, number2);
		}

		public static BigNumber operator -(BigNumber number1, BigNumber number2)
		{
			return Calculator.Minus(number1, number2);
		}
		public static BigNumber operator *(BigNumber number1, BigNumber number2)
		{
			return Calculator.Multiply(number1, number2);
			
		}
		public static BigNumber operator /(BigNumber number1, BigNumber number2)
		{
			return Calculator.Divider(number1, number2);
		}
		public static bool operator ==(BigNumber number1, BigNumber number2)
		{
			return Calculator.AreEqual(number1, number2);
		}

		public static bool operator !=(BigNumber number1, BigNumber number2)
		{
			return !Calculator.AreEqual(number1, number2);
		}

		public static bool operator >(BigNumber number1, BigNumber number2)
		{
			return Calculator.IsMore(number1, number2);
		}

		public static bool operator <(BigNumber number1, BigNumber number2)
		{
			return !Calculator.IsMore(number1, number2);
		}
		private bool IsSign(char symbol)
		{
			return symbol == '+' || symbol == '-';
		}

		private void SetSigne(char symbol)
		{
			switch (symbol)
			{
				case '-':
					IsPositive = false;
					break;
				default:
					IsPositive = true;
					break;
			}
		}

		private int ConvertCharToDigit(char symbol)
		{
			return (int)Char.GetNumericValue(symbol);
		}
	}
}

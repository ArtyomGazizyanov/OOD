using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace LongMath
{
	public class BigNumber
	{
		public bool EqualsDigits(BigNumber other)
		{
			if (other.Digits.Count != Digits.Count)
			{
				return false;
			}

			for (int i = 0; i < other.Digits.Count; ++i)
			{
				if (other.Digits[i] != Digits[i])
				{
					return false;
				}
			}

			return true;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((BigNumber) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Digits != null ? Digits.GetHashCode() : 0) * 397) ^ IsPositive.GetHashCode();
			}
		}

		public List<int> Digits { get; } = new List<int>();
		public bool IsPositive { get; private set; } = true;

		public BigNumber()
		{
		}

		public BigNumber(BigNumber donor)
		{
			Digits = donor.Digits;
			IsPositive = donor.IsPositive;

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
			/*int[] digitCopyArray = { };
			Digits.CopyTo(digitCopyArray);
			List<int> digitCopy = digitCopyArray.ToList();*/

			//digitCopy.Reverse();

			string resultString = String.Empty;
			for (int i = Digits.Count - 1; i >= 0; --i)
			{
				resultString += Digits[i];
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
		public static BigNumber operator *(double number1, BigNumber number2)
		{
			return Calculator.Multiply(number1, number2);
		}
		public static BigNumber operator *(BigNumber number2, double number1)
		{
			return Calculator.Multiply(number1, number2);
		}
		public static BigNumber operator /(BigNumber number1, BigNumber number2)
		{
			return Calculator.Divider(number1, number2);
		}
		public static BigNumber operator /(BigNumber number1, double number2)
		{
			return Calculator.Divider(number1, number2);
		}
		public static BigNumber operator /(double number1, BigNumber number2)
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

		public static bool operator <=(BigNumber number1, BigNumber number2)
		{
			return number1 < number2 || number1 == number2;
		}

		public static bool operator >=(BigNumber number1, BigNumber number2)
		{
			return number1 > number2 || number1 == number2;
		}

		public void RemoveDigitsAtBeginnig(int ammountToRemove)
		{
			Digits.RemoveRange(0, ammountToRemove);
		}

		public BigNumber Sqrt()
		{
			BigNumber l = new BigNumber("0");
			BigNumber r = new BigNumber(Digits);
			BigNumber res = this;
			BigNumber oneNumber = new BigNumber("1");
			while (l == r || l < r)
			{
				BigNumber m = (l + r) / 2;
				BigNumber squareM = Calculator.Pow(m, 2);
				if (EqualsDigits(squareM) || squareM < this)
				{
					res = m;
					l = m + oneNumber;
				}
				else
					r = m - oneNumber;
			}

			if (res.Digits.Count > 1 && res.Digits[0] != 0)
			{
				res = res + oneNumber;
			}

			return res;
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

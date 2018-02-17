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
			BigNumber r = new BigNumber(this);
			BigNumber res = new BigNumber(this);
			BigNumber oneNumber = new BigNumber("1");

			while (l == r || l < r)
			{
				BigNumber m = (l + r) / 2;
				BigNumber squareM = Calculator.Pow(m, 2);
				//squareM.Digits.Reverse();
				if (squareM.Digits.Equals(Digits) /*|| squareM < this*/)
				{
					res = m;
					l = m + oneNumber;
				}
				else
					r = m - oneNumber;
			}

			return res;
		}
		public BigNumber Sqrta()
		{
			BigNumber cur = this;
			// максимальное количество разрядов в ответе
			int pos = (Digits.Count + 1) / 2;
			//cur.amount = pos;
			pos--;
			while (pos >= 0)
			{
				int l = 0, r = 2;
				int curDigit = 0;
				while (l <= r) // подбираем текущую цифру
				{
					int m = (l + r) >> 1;
					cur.Digits[pos] = m;
					if (cur * cur <= this)
					{
						curDigit = m;
						l = m + 1;
					}
					else
						r = m - 1;
				}
				cur.Digits[pos] = curDigit;
				pos--;
			}
			return cur;
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

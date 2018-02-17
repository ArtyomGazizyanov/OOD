using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LongMath
{
	public static class Calculator
	{
		public static BigNumber Plus(BigNumber number1, BigNumber number2)
		{
			if (number1?.Digits == null || number2?.Digits == null)
			{
				throw new ArgumentNullException();
			}

			List<int> resultDigits = new List<int>();
			int carry = 0;
			int maxNumberSize = Math.Max(number1.Digits.Count, number2.Digits.Count);
			for (int i = 0; i < maxNumberSize; i++)
			{
				int tempA = (number1.Digits.Count > i) ? number1.Digits[i] : 0;
				int tempB = (number2.Digits.Count > i) ? number2.Digits[i] : 0;
				int sum = tempA + tempB + carry;
				carry = 0;

				if (sum >= 10)
				{
					sum -= 10;
					carry = 1;
				}
				resultDigits.Add(sum);

				if (i == maxNumberSize - 1)
				{
					resultDigits.Add(carry);
				}
			}
			while (resultDigits.Count > 1 && resultDigits[resultDigits.Count - 1] == 0)
			{
				resultDigits.RemoveAt(resultDigits.Count - 1);
			}
			return new BigNumber(resultDigits);
		}

		public static BigNumber Minus(BigNumber number1, BigNumber number2)
		{
			if (number1?.Digits == null || number2?.Digits == null)
			{
				throw new ArgumentNullException();
			}

			if (number1 < number2)
			{
				BigNumber tempNumber = number1;
				number1 = number2;
				number2 = tempNumber;
				//throw new ArgumentException("Left number can`t be greater than right number");
			}
			List<int> resultDigits = new List<int>();
			int carry = 0;
			bool isPositive = true;
			
			for (int i = 0; i < number1.Digits.Count; i++)
			{
				int tempA = (number1.Digits.Count > i) ? number1.Digits[i] : 0;
				int tempB = (number2.Digits.Count > i) ? number2.Digits[i] : 0;
				int sum = tempA - tempB - carry;

				carry = sum < 0 ? 1 : 0;

				sum +=
					carry == 1
					&& i != number1.Digits.Count - 1
						? 10
						: 0;
				
				resultDigits.Add(sum);

				if (i == number1.Digits.Count && carry == 1)
				{
					isPositive = false;
				}
			}
			while (resultDigits.Count > 1 && resultDigits[resultDigits.Count - 1] == 0)
			{
				resultDigits.RemoveAt(resultDigits.Count - 1);
			}

			return new BigNumber(resultDigits, isPositive);
		}
		
		public static BigNumber Multiply(BigNumber number1, BigNumber number2)
		{
			if (number1?.Digits == null || number2?.Digits == null)
			{
				throw new ArgumentNullException();
			}
			if (number1.Digits.TrueForAll(m => m == 0) || number2.Digits.TrueForAll(m => m == 0))
			{
				return new BigNumber("0");
			}
			List<BigNumber> summands = new List<BigNumber>(number1.Digits.Count);
			for (int i = 0; i < number1.Digits.Count; ++i)
			{
				ArrayList iniciaiztion = ArrayList.Repeat(0, i);
				summands.Add(
					new BigNumber(iniciaiztion.Cast<int>().ToList())
					);
			}

			for (int i = 0; i < number1.Digits.Count; ++i)
			{
				int carried = 0;
				for (int j = 0; j < number2.Digits.Count; ++j)
				{
					var multiplied = number1.Digits[i] * number2.Digits[j] + carried;
					carried = multiplied / 10;
					multiplied %=  10;
					summands[i].Digits.Add(multiplied);

					while (carried != 0 && number2.Digits.Count - 1 == j)
					{
						int additional = carried;
						if (carried > 10)
						{
							carried /= 10;
							additional = carried % 10;
						}
						else
						{
							carried = 0;
						}
						summands[i].Digits.Add(additional);
					}
				}
			}

			BigNumber result = new BigNumber();

			summands.ForEach(m => result += m);

			return result;
		}
		public static BigNumber Multiply(double number1, BigNumber number2)
		{
			return Multiply(new BigNumber(number1.ToString()), number2);
		}
		public static BigNumber Pow(BigNumber number2, int count)
		{
			BigNumber answer = number2;
			for (int i = 0; i < count - 1; ++i)
			{
				answer = Multiply(answer, number2);
			}
			return answer;
		}

		public static bool AreEqual(BigNumber number1, BigNumber number2)
		{
			if (number1?.Digits == null && number2?.Digits == null)
			{
				return true;
			}

			if (number1?.Digits == null || number2?.Digits == null)
			{
				return false;
			}

			return number1.Digits.Equals(number2.Digits);
		}

		public static bool IsMore(BigNumber number1, BigNumber number2)
		{
			if (AreEqual(number1, number2))
			{
				return false;
			}

			if (number1.Digits.Count == number2.Digits.Count)
			{
				for (int i = number1.Digits.Count - 1; i >= 0; --i)
				{
					if (number1.Digits[i] == number2.Digits[i])
					{
						continue;
					}
					return number1.Digits[i] > number2.Digits[i];
				}
			}

			if (number1.Digits.Count < number2.Digits.Count)
			{
				return false;
			}
			return true;
		}

		public static BigNumber Divider(BigNumber left, BigNumber right)
		{
			if (left?.Digits == null || right?.Digits == null)
			{
				throw new ArgumentNullException();
			}
			if (left.Digits.TrueForAll(m => m == 0))
			{
				return new BigNumber("0");
			}
			if (right.Digits.TrueForAll(m => m == 0))
			{
				throw new DivideByZeroException();
			}

			BigNumber result = new BigNumber();
			BigNumber tmp2 = new BigNumber(); ;
			while (tmp2 < left || tmp2 == left)
			{
				BigNumber multiplier = new BigNumber("1");
				BigNumber tmp = right;
				BigNumber previousMultiplier = multiplier;
				while (tmp2 + tmp<left)
				{
					previousMultiplier = multiplier;
					multiplier = multiplier + multiplier;
					tmp = right* multiplier;
				}
				tmp2 = tmp2 + right* previousMultiplier;
				result = result + previousMultiplier;
			}
			return result;
		}
		public static BigNumber Divider(BigNumber left, double right)
		{
			return Divider(left, new BigNumber(right.ToString()));
		}
		public static BigNumber Divider(double left, BigNumber right)
		{
			return Divider(new BigNumber(left.ToString()), right);
		}
		public static BigNumber GetСoercedPiNumber(int cutPosition)
		{
			if (cutPosition > 15)
			{
				cutPosition = 15;
			}
			string piNumber = Math.PI.ToString().Replace(",", String.Empty);
			piNumber = piNumber.Substring(0, cutPosition);

			return new BigNumber(piNumber);
		}
	}
}

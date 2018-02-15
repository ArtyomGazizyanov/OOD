using System;
using System.Collections.Generic;
using System.Linq;
using LongMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongMathTest
{
	[TestClass]
	public class BigNumberTest
	{
		[TestMethod]
		public void Constructor_CreateEmptyObject_BigNumberEntity()
		{
			BigNumber number = new BigNumber();
			Assert.IsNotNull(number);
		}

		[TestMethod]
		public void Constructo_InitWithList_BigNumberEntity()
		{
			List<int> numberList = new List<int>();
			BigNumber number = new BigNumber(numberList);
			Assert.AreEqual(number.Digits, numberList);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructo_InitnullList_BigNumberEntity()
		{
			BigNumber number = new BigNumber(null);
			Assert.IsNotNull(number.Digits);
		}

		[TestMethod]
		public void Constructo_InitWithString_ReversedDigitsList()
		{
			BigNumber number = new BigNumber("123");
			List<int> expectedDigitList = new List<int>()
			{
				3, 2, 1
			};

			var firstNotSecond = number.Digits.Except(expectedDigitList).ToList();
			var secondNotFirst = expectedDigitList.Except(number.Digits).ToList();

			Assert.AreEqual(!firstNotSecond.Any(), !secondNotFirst.Any());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Constructo_InitNullString_BigNumberEntity()
		{
			BigNumber number = new BigNumber(null);
			Assert.IsNotNull(number.Digits);
		}

		[TestMethod]
		public void Constructo_InitEmptyString_BigNumberEntity()
		{
			BigNumber number = new BigNumber(String.Empty);
			Assert.IsNotNull(number.Digits);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructo_InitinvalidSymbolsInString_BigNumberEntity()
		{
			BigNumber number = new BigNumber("1(272");
		}

		[TestMethod]
		public void ToString_NumberInStringFormat_NumberInStringFormat()
		{
			string numberStr = "123";
			BigNumber number = new BigNumber(numberStr);

			Assert.AreEqual(number.ToString(), numberStr);
		}

		[TestMethod]
		public void OperatorPlus_PlusTwoLargeNumbers_CorrectSummand()
		{
			BigNumber number1 = new BigNumber("123");
			BigNumber number2 = new BigNumber("1234");
			string answer = "1357";

			BigNumber number3 = number1 + number2;

			Assert.AreEqual(number3.ToString(), answer);
		}

		[TestMethod]
		public void OperatorMinus_MinusTwoLargeNumbers_CorrectSummand()
		{
			BigNumber number1 = new BigNumber("15630126455");
			BigNumber number2 = new BigNumber("11897654123");
			string answer = "3732472332";

			BigNumber number3 = number1 - number2;

			Assert.AreEqual(number3.ToString(), answer);
		}

		[TestMethod]
		public void OperatorMultiply_MultiplyTwoLargeNumbers_CorrectSummand()
		{
			BigNumber number1 = new BigNumber("8963459789");
			BigNumber number2 = new BigNumber("6666666666");
			string answer = "59756398587357693474";

			BigNumber number3 = number1 * number2;

			Assert.AreEqual(number3.ToString(), answer);
		}

		[TestMethod]
		public void OperatorDivide_DivideTwoLargeNumbers_CorrectSummand()
		{
			BigNumber number1 = new BigNumber("59756398587357693474");
			BigNumber number2 = new BigNumber("6666666666");
			string answer = "8963459789";

			BigNumber number3 = number1 / number2;

			Assert.AreEqual(number3.ToString(), answer);
		}

		[TestMethod]
		public void OperatorMore_CompareTwoLargeNumbers_True()
		{
			BigNumber number1 = new BigNumber("59756398587357693474");
			BigNumber number2 = new BigNumber("6666666666");

			bool result = number1 > number2; 

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void OperatorMore_CompareTwoLargeNumbers_False()
		{
			BigNumber number1 = new BigNumber("59756398587357693474");
			BigNumber number2 = new BigNumber("6666666666");

			bool result = number1 < number2;

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void OperatorEqual_CompareTwoLargeNumbers_True()
		{
			BigNumber number1 = new BigNumber("59756398587357693474");
			BigNumber number2 = number1;

			bool result = number1 == number2;

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void OperatorEqual_CompareTwoLargeNumbers_False()
		{
			BigNumber number1 = new BigNumber("59756398587357693474");
			BigNumber number2 = new BigNumber("123456789");

			bool result = number1 == number2;

			Assert.IsFalse(result);
		}
	}
}

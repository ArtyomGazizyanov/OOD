using System;
using LongMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongMathTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Plus_CommonCaseTwoLargeNumbers_CorrectAnswer()
        {
			BigNumber number1 = new BigNumber("6666666666");
			BigNumber number2 = new BigNumber("8963459789");
	        string correctAnswer = "15630126455";

			BigNumber number3 = Calculator.Plus(number1, number2);
			
	        Assert.AreEqual(number3.ToString(), correctAnswer);
        }

	    [TestMethod]
	    public void Plus_LargeAndShortNumbers_CorrectAnswer()
	    {
		    BigNumber number1 = new BigNumber("55");
		    BigNumber number2 = new BigNumber("8963459789");
		    string correctAnswer = "8963459844";

		    BigNumber number3 = Calculator.Plus(number1, number2);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    public void Plus_LargeAndShortIntRightArgumentNumbers_CorrectAnswer()
	    {
		    BigNumber number1 = new BigNumber("55");
		    BigNumber number2 = new BigNumber("8963459789");
		    string correctAnswer = "8963459844";

		    BigNumber number3 = Calculator.Plus(number2, number1);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    public void Plus_LargeAndZero_SameLargeNumber()
	    {
		    BigNumber number1 = new BigNumber("0");
		    BigNumber number2 = new BigNumber("8963459789");
		    string correctAnswer = "8963459789";

		    BigNumber number3 = Calculator.Plus(number2, number1);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    public void Plus_ZeroAndZero_Zeror()
	    {
		    BigNumber number1 = new BigNumber("0");
		    BigNumber number2 = new BigNumber("0");
		    string correctAnswer = "0";

		    BigNumber number3 = Calculator.Plus(number2, number1);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    [ExpectedException(typeof(ArgumentNullException))]
		public void Plus_NullParameter_Exception()
	    {
		    BigNumber number1 = null;
		    BigNumber number2 = new BigNumber("0");

		    BigNumber number3 = Calculator.Plus(number2, number1);
	    }

	    [TestMethod]
	    public void  Minus_CommonCaseTwoLargeNumbers_CorrectAnswer()
	    {
		    BigNumber number1 = new BigNumber("15630126455");
		    BigNumber number2 = new BigNumber("11897654123");
		    string correctAnswer = "3732472332";

		    BigNumber number3 = Calculator.Minus(number1, number2);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    public void Minus_LargeAndShortNumbers_CorrectAnswer()
	    {
		    BigNumber number1 = new BigNumber("15630126455");
		    BigNumber number2 = new BigNumber("5");
		    string correctAnswer = "15630126450";

		    BigNumber number3 = Calculator.Minus(number1, number2);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    [ExpectedException(typeof(ArgumentException))]
		public void Minus_ShortAndLarge_ArgumentException()
	    {
		    BigNumber number1 = new BigNumber("15630126455");
		    BigNumber number2 = new BigNumber("5");
		    string correctAnswer = "3732472330";

		    BigNumber number3 = Calculator.Minus(number2, number1);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    [ExpectedException(typeof(ArgumentNullException))]
	    public void Minus_NullLeftArgumentAndLarge_ArgumentNullException()
	    {
		    BigNumber number1 = new BigNumber("15630126455");
		    BigNumber number2 = null;

		    BigNumber number3 = Calculator.Minus(number2, number1);
	    }

	    [TestMethod]
	    [ExpectedException(typeof(ArgumentNullException))]
	    public void Minus_NullRightArgumentAndLarge_ArgumentNullException()
	    {
		    BigNumber number1 = new BigNumber("15630126455");
		    BigNumber number2 = null;

		    BigNumber number3 = Calculator.Minus(number1, number2);
	    }

	    [TestMethod]
	    public void Multiply_CommonCaseTwoLargeNumbers_CorrectAnswer()
	    {
		    BigNumber number1 = new BigNumber("8963459789");
		    BigNumber number2 = new BigNumber("6666666666");
		    string correctAnswer = "59756398587357693474";

		    BigNumber number3 = Calculator.Multiply(number1, number2);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    public void Multiply_LargeAndShortNumbers_CorrectAnswer()
	    {
		    BigNumber number1 = new BigNumber("8");
		    BigNumber number2 = new BigNumber("6666666666");
		    string correctAnswer = "53333333328";

		    BigNumber number3 = Calculator.Multiply(number1, number2);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    public void Multiply_LargeAndZeroLeftNumbers_Zero()
	    {
		    BigNumber number1 = new BigNumber("0");
		    BigNumber number2 = new BigNumber("6666666666");
		    string correctAnswer = "0";

		    BigNumber number3 = Calculator.Multiply(number1, number2);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    public void Multiply_LargeAndZeroRightNumbers_Zero()
	    {
		    BigNumber number1 = new BigNumber("0");
		    BigNumber number2 = new BigNumber("6666666666");
		    string correctAnswer = "0";

		    BigNumber number3 = Calculator.Multiply(number2, number1);

		    Assert.AreEqual(number3.ToString(), correctAnswer);
	    }

	    [TestMethod]
	    [ExpectedException(typeof(ArgumentNullException))]
		public void Multiply_LargeAndNullLeftArgument_Exception()
	    {
		    BigNumber number1 = null;
		    BigNumber number2 = new BigNumber("6666666666");

		    Calculator.Multiply(number1, number2);
	    }

	    [TestMethod]
	    [ExpectedException(typeof(ArgumentNullException))]
	    public void Multiply_LargeAndNullRightArgument_Exception()
	    {
		    BigNumber number1 = null;
		    BigNumber number2 = new BigNumber("6666666666");

		    Calculator.Multiply(number2, number1);
	    }

	    [TestMethod]
	    public void AreEqual_NullArguments_True()
	    {
		    BigNumber number1 = null;
		    BigNumber number2 = null;

		    Assert.IsTrue(Calculator.AreEqual(number2, number1));
	    }

	    [TestMethod]
	    public void AreEqual_LeftNullArgumentAndNumber_False()
	    {
		    BigNumber number1 = null;
		    BigNumber number2 = new BigNumber("6666666666");

			Assert.IsFalse(Calculator.AreEqual(number2, number1));
	    }

	    [TestMethod]
	    public void AreEqual_EquallargeNumbers_True()
	    {
		    BigNumber number1 = new BigNumber("6666666666");
		    BigNumber number2 = number1;

		    Assert.IsTrue(Calculator.AreEqual(number2, number1));
	    }
	    [TestMethod]
	    public void AreEqual_NotEquallargeNumbers_False()
	    {
		    BigNumber number1 = new BigNumber("6666666666");
		    BigNumber number2 = new BigNumber("123");

			Assert.IsFalse(Calculator.AreEqual(number2, number1));
	    }

	    [TestMethod]
	    public void IsMore_LeftGreaterThanRight_True()
	    {
		    BigNumber number1 = new BigNumber("6666666666");
		    BigNumber number2 = new BigNumber("123");

		    Assert.IsTrue(Calculator.IsMore(number1, number2));
	    }
	}
}

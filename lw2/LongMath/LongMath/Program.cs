using System;

namespace LongMath
{
    class Program
    {
        static void Main(string[] args)
        {
			BigNumber number1 = new BigNumber("59756398587357693474");
			BigNumber number2 = new BigNumber("6666666666");
			var number3 = number1 / number2;
			Console.WriteLine(number3.ToString());
         }
    }
}

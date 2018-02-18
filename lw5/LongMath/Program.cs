using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LongMath
{
    class Program
    {

        static void Main(string[] args)
        {
	        if (args.Length < 1)
	        {
		        Console.WriteLine("Invalid parameters count");
	        }

	        StreamReader file = new StreamReader(args[0]);
	        string str;
			
	        while ((str = file.ReadLine()) != null)
	        {
				List<string> operands = str.Split(' ').ToList();
		        BigNumber left = new BigNumber(operands[0]);
		        BigNumber right = new BigNumber(operands[2]);

		        BigNumber answer = MathHelpler.ResolveOperator(operands[1], left, right);
		        Console.WriteLine(answer.ToString());
			}
		}
    }
}

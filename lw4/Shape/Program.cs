﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LongMath;
using Shape.Creators;

namespace Shape
{
	class Program
	{
		const string CIRCLE = "CIRCLE";
		const string TRIANGLE = "TRIANGLE";
		const string RECTANGLE = "RECTANGLE";

		static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				Console.WriteLine("Invalid parameters count");
			}

			StreamReader file = new StreamReader(args[0]);
			string str;
			List<Shape> shapes = new List<Shape>();
			string[] stringSeparators = {",", " ", ":", "P", "C", "=", ";", "R"};

			while ((str = file.ReadLine()) != null)
			{
				List<string> tokens = new List<string>();
				int index = str.IndexOf(':');
				string shapeName = str.Substring(0, index);
				int shapeNameSize = shapeName.Length + 2;
				string restString = str.Substring(shapeNameSize);

				if (shapeName == CIRCLE)
				{
					tokens = restString.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();

					Point point = new Point(tokens[0], tokens[1]);
					BigNumber radius = new BigNumber(tokens[2]);

					shapes.Add(CircleCreator.GetInstance().Create(point, radius));
				}

				if (shapeName == TRIANGLE)
				{
					tokens = restString.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();

					Point point1 = new Point(tokens[1], tokens[2]);
					Point point2 = new Point(tokens[4], tokens[5]);
					Point point3 = new Point(tokens[7], tokens[8]);

					shapes.Add(TriangleCreator.GetInstance().Create(point1, point2, point3));
				}

				if (shapeName == RECTANGLE)
				{
					tokens = restString.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();

					Point point1 = new Point(tokens[1], tokens[2]);
					Point point2 = new Point(tokens[4], tokens[5]);

					shapes.Add(RectangleCreator.GetInstance().Create(point1, point2));
				}
			}
			Printer.PrintCollection(shapes, "output.txt");
		}
	}
}


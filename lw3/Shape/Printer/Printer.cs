using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Shape.Creators
{
    public class Printer
    {
	    public static void PrintCollection(IEnumerable<IShape> collection, string fileName)
	    {
			using (StreamWriter output = new StreamWriter(fileName))
			{
				foreach (var shape in collection)
				{
					output.WriteLine(shape.GetName());
					output.WriteLine($"Square = {shape.GetSquare()}");
					output.WriteLine($"Perimeter = {shape.GetPerimeter()}");
					output.WriteLine();
				}
			}
		}
	}
}

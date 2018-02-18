using System.Collections.Generic;
using System.IO;

namespace Shape.Printer
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
					output.WriteLine($"Square = {shape.GetSquare().ToString()}");
					output.WriteLine($"Perimeter = {shape.GetPerimeter().ToString()}");
					output.WriteLine();
				}
			}
		}
	}
}

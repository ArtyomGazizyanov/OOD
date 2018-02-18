﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shape
{
    class ShapeVisitor : IShapeVisitor
    {
	    public void VisitShape(Shape shape)
	    {
		    Console.WriteLine($"Name = {shape.GetName()}");
		    Console.WriteLine($"Square = {shape.GetSquare().ToString()}");
		    Console.WriteLine($"Perimeter = {shape.GetPerimeter().ToString()}");
		    Console.WriteLine();
		}
    }
}

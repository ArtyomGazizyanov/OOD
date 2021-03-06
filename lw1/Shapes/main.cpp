// Shapes.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <boost/algorithm/string/classification.hpp> // Include boost::for is_any_of
#include <boost/algorithm/string/split.hpp> // Include for boost::split
std::string const CIRCLE = "CIRCLE";
std::string const TRIANGLE = "TRIANGLE";
std::string const RECTANGLE = "RECTANGLE";

int main(int argc, char *argv[])
{
	std::ifstream file(argv[1]);
	std::vector<CShape*> shapes;
	std::string str;

	while (getline(file, str))
	{
		std::vector<std::string> tokens;
		int foundIndex =  str.find_first_of(':');
		std::string shapeName = str.substr(0, foundIndex);
		size_t shapeNameSize = shapeName.length() + 2;
		std::string restString = str.substr(shapeNameSize, str.length());

		if(shapeName == CIRCLE)
		{
			std::string delims = " C=,;R";
			boost::split(tokens, restString, boost::is_any_of(delims), boost::token_compress_on);

			Point centerPoint(std::stoi(tokens[1]), std::stoi(tokens[2]));
			int radius = std::stoi(tokens[3]);

			shapes.push_back(new CCircle(centerPoint, radius));
		}
		if (shapeName == TRIANGLE)
		{
			boost::split(tokens, restString, boost::is_any_of(" =,;P"), boost::token_compress_on);

			Point point1(std::stoi(tokens[2]), std::stoi(tokens[3]));
			Point point2(std::stoi(tokens[5]), std::stoi(tokens[6]));
			Point point3(std::stoi(tokens[8]), std::stoi(tokens[9]));

			shapes.push_back(new CTriangle(point1, point2, point3));
		}
		if (shapeName == RECTANGLE)
		{
			boost::split(tokens, restString, boost::is_any_of(" =,;P"), boost::token_compress_on);

			Point point1(std::stoi(tokens[2]), std::stoi(tokens[3]));
			Point point2(std::stoi(tokens[5]), std::stoi(tokens[6]));

			shapes.push_back(new CRectangle(point1, point2));
		}
	}

	for each (CShape* shape in shapes)
	{
		std::cout << shape->GetName() << std::endl;
		std::cout << "Square =  " << shape->GetSquare() << std::endl;
		std::cout << "Perimeter = " << shape->GetPerimeter() << std::endl << std::endl;
	}

    return 0;
}


#pragma once
#include "CShape.h"
#include "Point.h"
#define _USE_MATH_DEFINES
#include "math.h"

class CCircle final :
	public CShape
{
public:
	CCircle(Point p1, int radius);

	double GetPerimeter() const override;
	double GetSquare() const override;
private:
	Point m_p1;
	int m_radius;
};

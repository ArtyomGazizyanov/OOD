#pragma once
#include "CShape.h"
#include "Point.h"

class CRectangle final :
	public CShape
{
public:
	CRectangle(Point p1, Point p2);

	double GetPerimeter() const override;
	double GetSquare() const override;
private:
	Point m_p1;
	Point m_p2;
};

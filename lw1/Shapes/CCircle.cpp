#include "stdafx.h"
#include "CCircle.h"

CCircle::CCircle(Point p1, int radius) : CShape("CIRCLE")
{
	m_p1 = p1;
	m_radius = radius;
}

double CCircle::GetPerimeter() const
{
	return 2 * M_PI * m_radius;
}

double CCircle::GetSquare() const
{
	return M_PI * pow(m_radius, 2);
}

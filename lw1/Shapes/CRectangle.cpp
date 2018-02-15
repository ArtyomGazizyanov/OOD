#include "stdafx.h"
#include "CRectangle.h"

CRectangle::CRectangle(Point p1, Point p2) : CShape("RECTANGLE")
{
	m_p1 = p1;
	m_p2 = p2;
}

double CRectangle::GetPerimeter() const
{
	return 2 * (abs(m_p1.GetX() - m_p2.GetX()) + abs(m_p1.GetY() - m_p2.GetY()));
}

double CRectangle::GetSquare() const
{
	return abs(m_p1.GetX()- m_p2.GetX()) * abs(m_p1.GetY() - m_p2.GetY());
}

#include "stdafx.h"
#include "CTriangle.h"

CTriangle::CTriangle(Point p1, Point p2, Point p3) : CShape("TRIANGLE")
{
	m_p1 = p1;
	m_p2 = p2;
	m_p3 = p3;
}

double CTriangle::GetPerimeter() const
{
	int a = sqrt(pow(m_p2.GetX() - m_p1.GetX(), 2) + pow(m_p2.GetY() - m_p1.GetY(), 2));
	int b = sqrt(pow(m_p3.GetX() - m_p1.GetX(), 2) + pow(m_p3.GetY() - m_p1.GetY(), 2));
	int c = sqrt(pow(m_p3.GetX() - m_p2.GetX(), 2) + pow(m_p3.GetY() - m_p2.GetY(), 2));

	return a + b + c;
}

double CTriangle::GetSquare() const
{
	return 0.5 * (((m_p1.GetX() - m_p3.GetX()) * (m_p2.GetY() - m_p3.GetY())) - ((m_p2.GetX() - m_p3.GetX()) * (m_p1.GetY() - m_p3.GetY())));
}

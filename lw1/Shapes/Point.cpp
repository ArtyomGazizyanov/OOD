#include "stdafx.h"
#include "Point.h"

Point::Point(int x, int y)
{
	m_x = x;
	m_y = y;
}

Point::Point()
{
	m_x = 0;
	m_y = 0;
}

int Point::GetX() const
{
	return m_x;
}

int Point::GetY() const
{
	return m_y;
}

Point& Point::operator=(Point & p)
{
	m_x = p.GetX();
	m_y = p.GetX();

	return *this;
}


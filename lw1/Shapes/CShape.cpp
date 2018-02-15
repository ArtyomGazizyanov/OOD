#include "stdafx.h"
#include "CShape.h"

CShape::CShape(const std::string & type)
{
	m_type = type;
}

CShape::~CShape()
{
}

std::string CShape::GetName() const
{
	return "Shape: " + m_type;
}


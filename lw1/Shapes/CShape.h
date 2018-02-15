#pragma once
#include <string>

class CShape
{
public:
	CShape(const std::string & type);

	std::string GetName() const;
	virtual double GetPerimeter() const = 0;
	virtual double GetSquare() const = 0;

	virtual ~CShape();

private:
	std::string m_type;
};
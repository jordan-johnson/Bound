#ifndef __UNIT_H__
#define __UNIT_H__

#include <vector>

#include "../../../layer/draw/BRectangle.h"
#include "UnitProperty.h"

class Unit : public BRectangle {
protected:
	std::vector<UnitProperty> properties;
	void addProperty(UnitProperty *p);
};

#endif
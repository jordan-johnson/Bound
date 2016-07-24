#ifndef __MAP_H__
#define __MAP_H__

#include <iostream>

#include "terrain/Tileset.h"

class Map {
protected:
	std::string name;
	void setName(std::string name);

	Tileset tileset;
public:
	std::string& getName();
};

#endif
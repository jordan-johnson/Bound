#ifndef __TILESET_H__
#define __TILESET_H__

#include "../../../../systemtools/Dictionary.h"
#include "Tile.h"

class Tileset {
protected:
	Dictionary<Tile> tiles;
};

#endif
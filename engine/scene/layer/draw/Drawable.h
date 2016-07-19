#ifndef __DRAWABLE_H__
#define __DRAWABLE_H__

#include "SDL.h"
#include "../../../systemtools/Vector2.h"

class Drawable {
protected:
	Vector2f position;
	Vector2u size;
public:
	Vector2f& getPosition() {
		return position;
	}

	Vector2u& getSize() {
		return size;
	}
};

#endif
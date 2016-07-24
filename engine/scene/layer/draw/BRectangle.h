#ifndef __BRECTANGLE_H__
#define __BRECTANGLE_H__

#include "Drawable.h"

class BRectangle : public Drawable {
public:
	virtual void create(Vector2<float> position, Vector2<unsigned int> size);
};

#endif
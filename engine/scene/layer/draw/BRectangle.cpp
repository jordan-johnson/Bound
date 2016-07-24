#include "BRectangle.h"

void BRectangle::create(Vector2<float> position, Vector2<unsigned int> size) {
	SDL_Rect rect;
	rect.x = position.x;
	rect.y = position.y;
	rect.w = size.x;
	rect.h = size.y;

	this->rect = rect;
}
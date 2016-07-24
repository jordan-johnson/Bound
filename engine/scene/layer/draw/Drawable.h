#ifndef __DRAWABLE_H__
#define __DRAWABLE_H__

#include <memory>
#include <iostream>

#include "SDL.h"
#include "SDL_image.h"
#include "../../../systemtools/Vector2.h"

struct deleteTexture {
	void operator()(SDL_Texture *t) const {
		if(t != nullptr)
			SDL_DestroyTexture(t);
	}
};

typedef std::unique_ptr<SDL_Texture, deleteTexture> texturePtr;

class Drawable {
protected:
	SDL_Renderer *renderer;

	SDL_Rect rect;

	texturePtr texture;
public:
	SDL_Rect& getRect() {
		return rect;
	}

	void setTexture(std::string path) {
		if(renderer != nullptr) {
			texture = texturePtr(IMG_LoadTexture(renderer, path.c_str()));
		}
	}

	void setRenderer(SDL_Renderer *renderer) {
		this->renderer = renderer;
	}
	
	SDL_Texture& getTexture() {
		return *texture;
	}

	void draw() {
		if(renderer != nullptr && texture != nullptr) {
			SDL_RenderCopy(renderer, texture.get(), NULL, &getRect());
		}
	}
};

#endif
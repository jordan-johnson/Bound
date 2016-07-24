#ifndef __SCENE_H__
#define __SCENE_H__

#include "SDL.h"

#include "../systemtools/Input.h"
#include "layer/LayerHandler.h"
#include "../systemtools/JSONScript.h"

class Scene
{
protected:
	SDL_Renderer *renderer;
	Input input;
	LayerHandler layerhandler;
	JSONScript json;

	std::string sceneName = std::string();
public:
	/**
	 * Automate scene setup
	 */

	virtual void setRenderer(SDL_Renderer *r) {
		renderer = r;
	}

	virtual void inputListener(SDL_Event* e) {
		input.eventHandler(e);
	}

	/**
	 * Scene name funcs
	 */

	virtual void setSceneName(std::string name) {
		sceneName = name;
	}

	virtual std::string getSceneName() {
		return sceneName;
	}

	/**
	 * Requires override
	 */

	virtual void setup() = 0;
	virtual void update() = 0;
};

#endif
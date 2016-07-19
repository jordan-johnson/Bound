#ifndef __SCENE_H__
#define __SCENE_H__

#include "SDL.h"

#include "../systemtools/Input.h"
#include "layer/LayerHandler.h"
#include "../systemtools/JSONScript.h"

class Scene
{
protected:
	Input input;
	LayerHandler layerhandler;
	JSONScript json;

	std::string sceneName = std::string();
public:
	virtual std::string getSceneName() {
		return sceneName;
	}

	virtual void setup() = 0;
	virtual void inputListener(SDL_Event* e) = 0;
	virtual void update() = 0;
};

#endif
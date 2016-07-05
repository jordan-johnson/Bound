#ifndef __SCENEHANDLER_H__
#define __SCENEHANDLER_H__

#include <map>
#include <memory>

#include <SDL.h>
#include "Scene.h"
#include "../systemtools/ErrorLog.h"

typedef std::unique_ptr<Scene> scenePtr;
typedef std::map<std::string, scenePtr> sceneMap;

class SceneHandler {
private:
	sceneMap scenes;
	SDL_Renderer *renderer;
public:
	SceneHandler(){};
	SceneHandler(SDL_Renderer *renderer);

	void setRenderer(SDL_Renderer *renderer);
	void add(std::string name, Scene *scene);

	Scene& get(std::string name);
	sceneMap& getAll();
};

#endif
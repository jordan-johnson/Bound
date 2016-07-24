#ifndef __SCENEHANDLER_H__
#define __SCENEHANDLER_H__

#include <map>
#include <memory>

#include <SDL.h>
#include "../systemtools/ErrorLog.h"

#include "scenes/MainScene.h"
#include "scenes/GameScene.h"

typedef std::unique_ptr<Scene> scenePtr;
typedef std::map<std::string, scenePtr> sceneMap;

class SceneHandler {
private:
	sceneMap scenes;
	SDL_Renderer *renderer;
	static std::string currentScene;
public:
	SceneHandler(){};
	SceneHandler(SDL_Renderer *renderer);

	void setRenderer(SDL_Renderer *renderer);

	void init();
	void events(SDL_Event *e);
	void update();

	void add(std::string name, Scene *scene);

	static void set(std::string name);

	std::string getCurrentScene();
	Scene& get(std::string name);
	sceneMap& getAll();
};

#endif
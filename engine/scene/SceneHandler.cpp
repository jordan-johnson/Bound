#include "SceneHandler.h"

SceneHandler::SceneHandler(SDL_Renderer *renderer) {
	setRenderer(renderer);
}

void SceneHandler::setRenderer(SDL_Renderer *renderer) {
	this->renderer = renderer;
}

void SceneHandler::add(std::string name, Scene *scene) {
	scenes.insert(std::make_pair(name, scenePtr(scene)));
}

Scene& SceneHandler::get(std::string name) {
	auto position = scenes.find(name);
	
	if(position == scenes.end()) {
		ErrorLog el("scenes");
		el.write("Scene could not be found.");
		el.close();
	}

	return *position->second;
}

sceneMap& SceneHandler::getAll() {
	return scenes;
}
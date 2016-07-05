#include "SceneHandler.h"

SceneHandler::SceneHandler(SDL_Renderer *renderer) {
	setRenderer(renderer);
}

void SceneHandler::setRenderer(SDL_Renderer *renderer) {
	this->renderer = renderer;

	isOperational = true;
}

void SceneHandler::add(std::string name, Scene *scene) {
	scenes.insert(std::make_pair(name, scenePtr(scene)));
}

/**
 * Initialize scenes
 * Renderer must be assigned
 */
void SceneHandler::init() {
	if(isOperational) {
		add("main", new MainScene());

		for (auto &i : getAll()) {
			i.second->setup();
		}
	} else {
		ErrorLog el("scenes");
		el.write("SceneHandler::renderer not set");
		el.close();
	}
}

Scene& SceneHandler::get(std::string name) {
	auto position = scenes.find(name);
	
	if(position == scenes.end()) {
		ErrorLog el("scenes");
		el.write("SceneHandler::scene could not be found");
		el.close();
	}

	return *position->second;
}

sceneMap& SceneHandler::getAll() {
	return scenes;
}
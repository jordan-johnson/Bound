#include "SceneHandler.h"

std::string SceneHandler::currentScene = std::string();

SceneHandler::SceneHandler(SDL_Renderer *renderer) {
	setRenderer(renderer);
}

void SceneHandler::setRenderer(SDL_Renderer *renderer) {
	this->renderer = renderer;
}

/**
 * Initialize scenes
 * Renderer must be assigned
 */
void SceneHandler::init() {
	if(renderer != NULL) {
		/**
		 * Declare scenes
		 */

		add("main", new MainScene());
		add("game", new GameScene());

		/**
		 * Setup scenes automatically
		 */
		for (auto &i : getAll()) {
			i.second->setRenderer(renderer);
			i.second->setup();
		}

		// Set default scene
		set("main");
	} else {
		ErrorLog el("scenes");
		el.write("SceneHandler::renderer not set");
		el.close();
	}
}

/**
 * Add scene to list
 */
void SceneHandler::add(std::string name, Scene *scene) {
	scenes.insert(std::make_pair(name, scenePtr(scene)));
}

/**
 * Set current scene
 */
void SceneHandler::set(std::string name) {
	currentScene = name;
}

/**
 * Update events on current scene
 */
void SceneHandler::events(SDL_Event *e) {
	/**
	 * Loop through all scenes, find
	 * the current scene and listen
	 * for input
	 */
	for(auto &i : getAll()) {
		if(i.second->getSceneName() == getCurrentScene()) {
			i.second->inputListener(e);
		}
	}
}

/**
 * Update current scene
 */
void SceneHandler::update() {
	SDL_RenderClear(renderer);

	/**
	 * Loop through all scenes, find
	 * the current scene update
	 * the scene
	 */
	for(auto &i : getAll()) {
		if(i.second->getSceneName() == getCurrentScene()) {
			i.second->update();
		}
	}

	SDL_RenderPresent(renderer);
}

std::string SceneHandler::getCurrentScene() {
	return currentScene;
}

/**
 * Get scene
 */
Scene& SceneHandler::get(std::string name) {
	auto position = scenes.find(name);
	
	if(position == scenes.end()) {
		ErrorLog el("scenes");
		el.write("SceneHandler::scene could not be found...RETURNED " + name);
		el.close();
	}

	return *position->second;
}

/**
 * Get all scenes
 */
sceneMap& SceneHandler::getAll() {
	return scenes;
}
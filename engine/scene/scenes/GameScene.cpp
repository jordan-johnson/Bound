#include "GameScene.h"

std::string GameScene::map = std::string();

void GameScene::setMap(std::string name) {
	map = name;
}

/**
 * SceneHandler automatically calls this function
 * but it wont know the map to grab. To fix this,
 * the update function will call setup and assign
 * isRunning bool to stop duplication
 */
void GameScene::setup() {
	if(map != std::string() && isRunning == false) {
		isRunning = true;

		setSceneName("game");

		json.setFile(map);

		layerhandler.add("terrain");
		layerhandler.add("units");
		layerhandler.add("interface");
	} else {
		// 
		setMap("mission1");
	}
	
}

void GameScene::update() {
	/**
	 * Continuously look for the map
	 * so setup can work as usual
	 */
	if(map != std::string() && isRunning == false) {
		setup();
	}
}
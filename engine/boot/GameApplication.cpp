#include "GameApplication.h"

void GameApplication::init() {
	gameWindow.create("Bound v1.0.0");

	loop();
}

void GameApplication::loop() {
	while(gameWindow.isOpen) {
		gameWindow.eventListener();

		gameWindow.draw();
	}
}
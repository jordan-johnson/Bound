#include "GameApplication.h"

void GameApplication::init() {
	gameWindow.create("Bound v1.0.0");

	loop();
}

void GameApplication::loop() {
	while(gameWindow.isOpen) {
		eventListener();

		gameWindow.draw();
	}
}

void GameApplication::eventListener() {
	while(SDL_PollEvent(&gameWindow.getEvents())) {
		if(gameWindow.getEvents().type == SDL_QUIT) {
			gameWindow.quit();
		}
	}
}
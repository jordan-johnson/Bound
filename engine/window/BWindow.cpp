#include "BWindow.h"

void BWindow::create(std::string title) {
	getWindowProperties();

	// Init window error log
	ErrorLog windowErrorLog("window");

	SDL_Init(SDL_INIT_EVERYTHING);

	window = SDL_CreateWindow(title.c_str(), SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, windowSize.x, windowSize.y, winFlag);

	if(window == NULL) {
		windowErrorLog.write("Window could not be created.");
		isOpen = false;
	}

	renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED);

	if(renderer == NULL) {
		windowErrorLog.write("Renderer could not be created.");
		isOpen = false;
	}

	// Window is running
	isOpen = true;

	setupSceneHandler();

	windowErrorLog.close();
}

void BWindow::eventListener() {
	while(SDL_PollEvent(&getEvents())) {
		scenehandler.events(&getEvents());
		if(getEvents().type == SDL_QUIT) {
			quit();
		}
	}

	scenehandler.update();
}

/**
 * Look at JSON file to get window properties
 */
void BWindow::getWindowProperties() {
	std::string file = (fileLocation == std::string()) ? "resources/main/window" : fileLocation;

	JSONScript js(file);

	windowSize.x = js.getInt("WIN_WIDTH", 800);
	windowSize.y = js.getInt("WIN_HEIGHT", 600);

	std::string isFullScreen = js.getString("WIN_FULLSCREEN", "false");

	if(isFullScreen == "true")
		winFlag = SDL_WINDOW_FULLSCREEN_DESKTOP;
	else
		winFlag = SDL_WINDOW_SHOWN;

	js.close();
}

void BWindow::setupSceneHandler() {
	scenehandler.setRenderer(renderer);
	scenehandler.init();
}

/**
 * Override the file location
 */
void BWindow::overrideFile(std::string file) {
	fileLocation = file;
}

void BWindow::quit() {
	isOpen = false;

	SDL_DestroyRenderer(renderer);
	SDL_DestroyWindow(window);
	SDL_Quit();
}

SDL_Window* BWindow::getWindow() {
	return window;
}

SDL_Event& BWindow::getEvents() {
	return bevent;
}
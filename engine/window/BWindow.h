#ifndef __BWINDOW_H__
#define __BWINDOW_H__

#include <iostream>

#include <SDL.h>
#include "../systemtools/Vector2.h"
#include "../systemtools/JSONScript.h"
#include "../systemtools/ErrorLog.h"
#include "../scene/SceneHandler.h"

class BWindow {
private:
	SDL_Window *window;
	SDL_Event bevent;
	SDL_Renderer *renderer;

	SceneHandler scenehandler;

	Vector2u windowSize;
	SDL_WindowFlags winFlag;

	// Location of JSON file
	std::string fileLocation;

	void getWindowProperties();
	void setupSceneHandler();
public:
	bool isOpen = false;

	void overrideFile(std::string file);
	void create(std::string title);
	void eventListener();
	void quit();

	SDL_Window* getWindow();
	SDL_Event& getEvents();
};

#endif
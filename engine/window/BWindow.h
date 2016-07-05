#ifndef __BWINDOW_H__
#define __BWINDOW_H__

#include <iostream>

#include <SDL.h>
#include "../systemtools/Input.h"
#include "../systemtools/JSONScript.h"
#include "../systemtools/ErrorLog.h"
#include "../scene/SceneHandler.h"

class BWindow {
private:
	SDL_Window *window;
	SDL_Event bevent;
	SDL_Renderer *renderer;

	Input input;
	SceneHandler scenehandler;

	// window properties
	unsigned int width, height;
	SDL_WindowFlags winFlag;
	std::string fileLocation;

	void getWindowProperties();
	void setupSceneHandler();
public:
	bool isOpen = false;

	void overrideFile(std::string file);
	void create(std::string title);
	void eventListener();
	void draw();
	void quit();

	SDL_Window* getWindow();
	SDL_Event& getEvents();
};

#endif
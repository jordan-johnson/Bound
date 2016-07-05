#ifndef __GAMEAPPLICATION_H__
#define __GAMEAPPLICATION_H__

#include "../window/BWindow.h"

class GameApplication {
private:
	BWindow gameWindow;

	void eventListener();
public:
	void init();
	void loop();
};

#endif
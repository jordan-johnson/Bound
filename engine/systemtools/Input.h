#ifndef __INPUT_H__
#define __INPUT_H__

#include <vector>

#include <SDL.h>

struct mouseButton {
	bool left = false, right = false;
};

class Input {
private:
	struct mousePosition {
		float x, y;
	};

	mouseButton currentMouseButton;
	mousePosition currentMousePosition;

	std::vector<SDL_Keycode> currentKeysPressed;

	bool isMouseDown = false;
	bool isMouseReleased = false;

	void setMousePosition(float x, float y);
	void setMouseButton(Uint8 button, bool isPressed = true);
public:
	bool isKeyPressed(SDL_Keycode key);
	bool isKeyPressed(std::string key);

	mousePosition getMousePosition();
	mouseButton getMouseButton();

	void eventHandler(SDL_Event *e);
};

#endif
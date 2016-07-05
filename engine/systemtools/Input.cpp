#include "Input.h"

/**
* Standard values for keys:
*
* A, B, C, D, E, F, G, H, I, J, L, M, N, O, P, Q, R, S, T,
* U, V, W, X, Y, Z
*
* Backspace, CapsLock, Down, Escape, F(X), Left Alt,
* Left Ctrl, Left, Left Shift, Right Alt, Right Ctrl, Right,
* Return, Right Shift, Space, Tab, Up
*
* Notes:
*
* Up/Down/Left/Right refers to arrow keys
* F(X) refers to function keys
*
* Other keys can be found @ https://wiki.libsdl.org/SDL_Keycode
*/

void Input::setMousePosition(float x, float y) {
	currentMousePosition.x = x;
	currentMousePosition.y = y;
}

/**
* Mouse button information
*
* SDL's (event) mouse button values are type Uint8
* Only values 1 (Left MB) and 3 (Right MB) are supported in my code
*/
void Input::setMouseButton(Uint8 button, bool isPressed) {

	if(button == 1)
		currentMouseButton.left = isPressed;
	else if(button == 3)
		currentMouseButton.right = isPressed;
}

bool Input::isKeyPressed(SDL_Keycode key)
{
	std::vector<SDL_Keycode>::iterator it;

	it = std::find(currentKeysPressed.begin(), currentKeysPressed.end(), key);

	if (it != currentKeysPressed.end())
		return true;

	return false;
}

bool Input::isKeyPressed(std::string key)
{
	SDL_Keycode tempKey;

	tempKey = SDL_GetKeyFromName(key.c_str());

	std::vector<SDL_Keycode>::iterator it;

	it = std::find(currentKeysPressed.begin(), currentKeysPressed.end(), tempKey);

	if (it != currentKeysPressed.end())
		return true;

	return false;
}

Input::mousePosition Input::getMousePosition() {
	return currentMousePosition;
}

mouseButton Input::getMouseButton() {
	return currentMouseButton;
}

void Input::eventHandler(SDL_Event *e) {
	isMouseDown = false;
	isMouseReleased = false;

	switch(e->type) {
		case SDL_KEYDOWN: {
			SDL_Keycode tempKey;

			tempKey = e->key.keysym.sym;

			if(!isKeyPressed(tempKey))
				currentKeysPressed.push_back(tempKey);

			break;
		}
		case SDL_KEYUP: {
			SDL_Keycode tempKey;

			tempKey = e->key.keysym.sym;

			std::vector<SDL_Keycode>::iterator it;

			it = std::find(currentKeysPressed.begin(), currentKeysPressed.end(), tempKey);

			if(isKeyPressed(tempKey))
				currentKeysPressed.erase(it);

			break;
		}
		case SDL_MOUSEMOTION: {
			setMousePosition(e->button.x, e->button.y);

			// For mouse click and drag
			if(e->button.state && SDL_BUTTON_LMASK)
				isMouseDown = true;
		}
		case SDL_MOUSEBUTTONDOWN:
			setMouseButton(e->button.button);
		break;
		case SDL_MOUSEBUTTONUP: {
			setMouseButton(e->button.button, false);
			isMouseReleased = true;

			break;
		}
	}
}
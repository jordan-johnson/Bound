#ifndef __LAYER_H__
#define __LAYER_H__

#include "draw/Button.h"

typedef std::unique_ptr<Drawable> drawablePtr;
typedef std::map<std::string, drawablePtr> drawableMap;

typedef std::unique_ptr<Button> buttonPtr;
typedef std::map<std::string, buttonPtr> buttonMap;

class Layer {
protected:
	drawableMap drawables;
	buttonMap buttons;
public:
	void addDrawable(std::string name, Drawable *drawable) {
		drawables.insert(std::make_pair(name, drawablePtr(drawable)));
	}

	void addButton(std::string name, Button *button) {
		buttons.insert(std::make_pair(name, buttonPtr(button)));
	}

	Drawable& getDrawable(std::string name) {
		return *drawables[name];
	}

	Button& getButton(std::string name) {
		return *buttons[name];
	}

	drawableMap& getDrawables() {
		return drawables;
	}

	buttonMap& getButtons() {
		return buttons;
	}
};

#endif
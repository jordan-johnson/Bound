#include "Button.h"

Button::Button() {
	status = statusTypes::inactive;
}

void Button::checkStatus(Vector2<float> mousePosition, bool clicked) {
	if((mousePosition.x > getRect().x) && (mousePosition.x < getRect().x + getRect().w) &&
	(mousePosition.y > getRect().y) && (mousePosition.y < getRect().y + getRect().h)) {
		setStatus(statusTypes::active);

		// Check if clicked
		if(clicked && action != nullptr) {
			std::cout << "called";
			action->perform();
		}
	} else {
		setStatus(statusTypes::inactive);
	}
}

void Button::setAction(ButtonAction *action, std::string argument) {
	this->action = action;
	this->action->argument = argument;
}

void Button::setStatus(Button::statusTypes type) {
	status = type;
}

Button::statusTypes& Button::getStatus() {
	return status;
}
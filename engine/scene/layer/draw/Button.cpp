#include "Button.h"

Button::Button() {
	status = statusTypes::inactive;
}

void Button::checkStatus(Vector2f mousePosition, bool clicked) {
	if((mousePosition.x > position.x) && (mousePosition.x < position.x + size.x) &&
	(mousePosition.y > position.y) && (mousePosition.y < position.y + size.y)) {
		setStatus(statusTypes::active);

		// Check if clicked
		if(clicked && action != nullptr) {
			//action.perform();
		}
	} else {
		setStatus(statusTypes::inactive);
	}
}

void Button::setAction(ButtonAction *action) {
	this->action = action;
}

void Button::setStatus(Button::statusTypes type) {
	status = type;
}

Button::statusTypes& Button::getStatus() {
	return status;
}
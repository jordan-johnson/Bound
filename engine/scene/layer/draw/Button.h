#ifndef __BUTTON_H__
#define __BUTTON_H__

#include "BRectangle.h"
#include "../../scenes/actions/ButtonAction.h"

class Button : public BRectangle {
public:
	Button();

	enum statusTypes {
		active, inactive
	};

	void checkStatus(Vector2f mousePosition, bool clicked = false);

	void setStatus(statusTypes type);

	void setAction(ButtonAction *action);

	statusTypes& getStatus();
private:
	ButtonAction* action = nullptr;
	statusTypes status;
};

#endif
#ifndef __BUTTONACTION_H__
#define __BUTTONACTION_H__

#include <iostream>

class ButtonAction {
public:
	std::string argument;
	virtual void perform() = 0;
};

#endif
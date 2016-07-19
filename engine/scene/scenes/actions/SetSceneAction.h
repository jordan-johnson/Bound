#ifndef __SETSCENEACTION_H__
#define __SETSCENEACTION_H__

#include "ButtonAction.h"
#include "../../SceneHandler.h"

class SetSceneAction : public ButtonAction {
public:
	std::string sceneName;

	virtual void perform() override;
};

#endif
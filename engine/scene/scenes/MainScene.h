#ifndef __MAINSCENE_H__
#define __MAINSCENE_H__

#include "actions/ButtonAction.h"
#include "../Scene.h"
#include "../SceneHandler.h"
#include "../layer/draw/Button.h"
#include "actions/SetSceneAction.h"

class MainScene : public Scene {
public:
	enum buttonActions {
		none,
		setScene
	};

	virtual void setup() override;
	virtual void update() override;
private:
	buttonActions getActionMatch(std::string const& actionName);
	void buildButtonActions();
	void getSceneButtons();
};

#endif
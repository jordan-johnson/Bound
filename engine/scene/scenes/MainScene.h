#ifndef __MAINSCENE_H__
#define __MAINSCENE_H__

#include "../Scene.h"
#include "../SceneHandler.h"
#include "../layer/draw/Button.h"
#include "actions\SetSceneAction.h"

class MainScene : public Scene {
private:
	void buildButtonActions();
	void getSceneButtons();
public:
	virtual void setup() override;
	virtual void inputListener(SDL_Event *e) override;
	virtual void update() override;
};

#endif
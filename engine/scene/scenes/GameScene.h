#ifndef __GAMESCENE_H__
#define __GAMESCENE_H__

#include "../Scene.h"

class GameScene : public Scene {
private:
	static std::string map;

	bool isRunning = false;
public:
	static void setMap(std::string name);

	virtual void setup() override;
	virtual void update() override;
};

#endif
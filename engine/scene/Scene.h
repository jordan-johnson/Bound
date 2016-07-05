#ifndef __SCENE_H__
#define __SCENE_H__

#include "../window/layer/LayerHandler.h"
#include "../systemtools/JSONScript.h"

class Scene
{
protected:
	LayerHandler layerhandler;
	JSONScript json;
public:
	virtual void setup() = 0;
};

#endif
#ifndef __LAYERHANDLER_H__
#define __LAYERHANDLER_H__

#include <map>
#include <memory>

#include <SDL.h>
#include "Layer.h"
#include "../../systemtools/ErrorLog.h"

typedef std::unique_ptr<Layer> layerPtr;
typedef std::map<std::string, layerPtr> layerMap;

class LayerHandler {
private:
	layerMap layers;
	SDL_Renderer *renderer;
public:
	LayerHandler(){};
	LayerHandler(SDL_Renderer *renderer);

	void setRenderer(SDL_Renderer *renderer);
	void add(std::string name, Layer *layer);

	Layer& get(std::string name);
	layerMap& getAll();
};

#endif
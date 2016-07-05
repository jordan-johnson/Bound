#include "LayerHandler.h"

LayerHandler::LayerHandler(SDL_Renderer *renderer) {
	setRenderer(renderer);
}

void LayerHandler::setRenderer(SDL_Renderer *renderer) {
	this->renderer = renderer;
}

void LayerHandler::add(std::string name, Layer *layer) {
	layers.insert(std::make_pair(name, layerPtr(layer)));
}

Layer& LayerHandler::get(std::string name) {
	auto position = layers.find(name);

	if(position == layers.end()) {
		ErrorLog el("scenes");
		el.write("Cannot find layer.");
		el.close();
	}

	return *position->second;
}

layerMap& LayerHandler::getAll() {
	return layers;
}
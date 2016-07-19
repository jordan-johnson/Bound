#include "LayerHandler.h"

void LayerHandler::add(std::string name) {
	layers.insert(std::make_pair(name, layerPtr(new Layer())));
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
#ifndef __LAYERHANDLER_H__
#define __LAYERHANDLER_H__

#include <map>
#include <memory>

#include "Layer.h"
#include "../../systemtools/ErrorLog.h"

typedef std::unique_ptr<Layer> layerPtr;
typedef std::map<std::string, layerPtr> layerMap;

class LayerHandler {
private:
	layerMap layers;
public:
	void add(std::string name);

	Layer& get(std::string name);
	layerMap& getAll();
};

#endif
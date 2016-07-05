#include "JSONScript.h"

JSONScript::JSONScript(std::string file) {
	setFile(file);
}

void JSONScript::setFile(std::string file) {
	exists = false;

	std::ifstream location(file + ".json");

	if (location.good()) {
		location >> data;
		exists = true;
	} else {
		errors = true;
	}
}

int JSONScript::getInt(std::string name, int value) {
	if(!errors)
		return data.get(name, value).asInt();

	return 0;
}

std::string JSONScript::getString(std::string name, std::string value) {
	if(!errors)
		return data.get(name, value).asString();

	return std::string();
}

float JSONScript::getFloat(std::string name, float value) {
	if (!errors)
		return data.get(name, value).asFloat();

	return 0.0f;
}

Json::Value& JSONScript::getData() {
	return data;
}
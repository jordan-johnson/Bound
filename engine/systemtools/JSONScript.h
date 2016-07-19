#ifndef __JSONSCRIPT_H__
#define __JSONSCRIPT_H__

#include <iostream>
#include <fstream>

#include <json/json.h>

class JSONScript {
private:
	Json::Value data;
	Json::Reader reader;

	std::ifstream file;

	const char* fileLocation;
public:
	JSONScript(){};
	JSONScript(std::string file);

	bool exists, errors;

	void setFile(std::string file);
	int getInt(std::string name, int value);
	std::string getString(std::string name, std::string value);
	float getFloat(std::string name, float value);
	void close();

	Json::Value& getData();
};

#endif
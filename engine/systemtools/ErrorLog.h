#ifndef __ERRORLOG_H__
#define __ERRORLOG_H__

#include <iostream>
#include <fstream>

#include "DateTime.h"

class ErrorLog {
private:
	std::string location;

	std::ofstream output;

	std::string getDateTime();
public:
	ErrorLog(std::string file);

	void write(std::string line);
	void close();
};

#endif
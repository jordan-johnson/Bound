#include "ErrorLog.h"

ErrorLog::ErrorLog(std::string file) {
	location = "errorlog/" + file + ".txt";

	output.open(location, std::ofstream::out | std::ofstream::app);
}

void ErrorLog::write(std::string line) {
	output << getDateTime().c_str() << std::endl;
	output << "---" << std::endl;
	output << line.c_str() << std::endl;
	output << std::endl;
}

std::string ErrorLog::getDateTime() {
	DateTime dt;

	return dt.getFormatted();
}

void ErrorLog::close() {
	output.close();
}
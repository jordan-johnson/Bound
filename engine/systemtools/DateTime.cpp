#include "DateTime.h"

/**
 * On call, current date and time are stored
 */
DateTime::DateTime() {
	time_t now;
	tm tstruct;
	char buf[80];

	time(&now);
	localtime_s(&tstruct, &now);

	strftime(buf, sizeof(buf), "%d/%m/%Y %X", &tstruct);

	currentDT = buf;
}

std::string& DateTime::getFormatted() {
	return currentDT;
}
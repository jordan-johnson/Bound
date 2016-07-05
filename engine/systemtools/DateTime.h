#ifndef __DATETIME_H__
#define __DATETIME_H__

#include <iostream>
#include <time.h>

class DateTime {
private:
	std::string currentDT;
public:
	DateTime();

	std::string& getFormatted();
};

#endif
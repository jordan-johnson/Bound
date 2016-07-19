#ifndef __DICTIONARY_H__
#define __DICTIONARY_H__

#include <memory>
#include <map>

template <class t> class Dictionary {
private:
	std::map<std::string, std::unique_ptr<t>> list;
public:
	void add(std::string name, t *type);
	std::unique_ptr<t>& get(std::string name);
	std::map<std::string, std::unique_ptr<t>>& getAll();
};

#endif
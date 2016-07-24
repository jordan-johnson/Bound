#ifndef __DICTIONARY_H__
#define __DICTIONARY_H__

#include <memory>
#include <map>

template <class t> class Dictionary {
private:
	std::map<std::string, std::unique_ptr<t>> list;
public:
	void add(std::string name, t *type) {
		list.insert(std::make_pair(name, std::unique_ptr<t>(type)));
	}

	t& get(std::string name) {
		return *list[name];
	}

	std::map<std::string, std::unique_ptr<t>>& getAll() {
		return list;
	}

	bool find(std::string name) {
		if(list.find(name) != list.end())
			return true;

		return false;
	}
};

#endif
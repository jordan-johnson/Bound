#include "Dictionary.h"

template<class t>
void Dictionary<t>::add(std::string name, t *type) {
	list.insert(std::make_pair(name, std::unique_ptr<t>(type)));
}

template<class t>
std::unique_ptr<t>& Dictionary<t>::get(std::string name) {
	return list[name];
}

template<class t>
std::map<std::string, std::unique_ptr<t>>& Dictionary<t>::getAll() {
	return list;
}
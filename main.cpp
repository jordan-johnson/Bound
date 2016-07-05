#include <SDL.h>
#include <stdio.h>

#include "engine/boot/GameApplication.h"

int main(int argc, char* args[]) {
	GameApplication Bound;

	Bound.init();

	return 0;
}
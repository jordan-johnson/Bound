#include "SetSceneAction.h"

void SetSceneAction::perform() {
	SceneHandler::set(argument);
}
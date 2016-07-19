#include "MainScene.h"

void MainScene::setup() {
	sceneName = "main";
	json.setFile("resources/main/scenes/main");

	layerhandler.add("background");
	layerhandler.add("buttons");
	layerhandler.add("console");

	buildButtonActions();

	getSceneButtons();
	
}

void MainScene::inputListener(SDL_Event *e) {
	input.eventHandler(e);

	
}

void MainScene::update() {
	// Set vector2f to mouse position
	Vector2f mousePosition;
	mousePosition.x = input.getMousePosition().x;
	mousePosition.y = input.getMousePosition().y;

	bool isClicked = (input.getMouseButton().left) ? true : false;

	/**
	 * Check for hover status of buttons
	 */
	for(auto &layer : layerhandler.getAll()) {
		for(auto &button : layer.second->getButtons()) {
			button.second->checkStatus(mousePosition, isClicked);
		}
	}
}

/**
 * Build possible button actions
 */
void MainScene::buildButtonActions() {
	//layerhandler.get("buttons").getButton("")
}

void MainScene::getSceneButtons() {
	// Get button list
	for(auto &button : json.getData()["buttons"]) {
		Button btn;
		std::string buttonName;
		buttonName = button["name"].asString();

		Vector2f rectPosition;
		rectPosition.x = button["position"][0].asFloat();
		rectPosition.y = button["position"][1].asFloat();

		Vector2u rectSize;
		rectSize.x = button["size"][0].asInt();
		rectSize.y = button["size"][1].asInt();

		// Create our button
		btn.create(rectPosition, rectSize);

		// Add button to layer's button list
		layerhandler.get("buttons").addButton(buttonName, new Button(btn));
	}
}
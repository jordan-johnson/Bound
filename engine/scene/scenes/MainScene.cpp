#include "MainScene.h"

void MainScene::setup() {
	setSceneName("main");

	json.setFile("resources/main/scenes/main");

	layerhandler.add("background");
	layerhandler.add("buttons");
	layerhandler.add("console");

	getSceneButtons();
}

void MainScene::update() {
	// Update mouse position
	Vector2<float> mousePosition;
	mousePosition.x = input.getMousePosition().x;
	mousePosition.y = input.getMousePosition().y;

	// Used in checking button status (if left mb click)
	bool isClicked = (input.getMouseButton().left) ? true : false;

	/**
	 * Update buttons
	 */
	for(auto &layer : layerhandler.getAll()) {
		for(auto &button : layer.second->getButtons()) {
			button.second->draw();
			button.second->checkStatus(mousePosition, isClicked);
		}
	}
}

/**
 * Check if action name matches enum
 * then return the enum
 */
MainScene::buttonActions MainScene::getActionMatch(std::string const& actionName) {
	if(actionName == "setScene") return MainScene::buttonActions::setScene;

	return MainScene::buttonActions::none;
}

/**
 * Get all buttons for the scene from
 * the json file
 */
void MainScene::getSceneButtons() {
	// Get button list
	for(auto &button : json.getData()["buttons"]) {
		// Create our button's name
		std::string buttonName;
		buttonName = button["name"].asString();

		// Create our button instance
		layerhandler.get("buttons").addButton(buttonName, new Button());
		Button& btn = layerhandler.get("buttons").getButton(buttonName);

		Vector2<float> rectPosition;
		rectPosition.x = button["position"][0].asFloat();
		rectPosition.y = button["position"][1].asFloat();

		Vector2<unsigned int> rectSize;
		rectSize.x = button["size"][0].asInt();
		rectSize.y = button["size"][1].asInt();

		Vector2<std::string> action;
		action.x = button["action"][0].asString();
		action.y = button["action"][1].asString();

		// Find action in dictionary
		switch(getActionMatch(action.x)) {
			case buttonActions::setScene:
				btn.setAction(new SetSceneAction(), action.y);
			break;
		}

		// Create our button
		btn.create(rectPosition, rectSize);

		/**
		 * Get & set image locations
		 * X = original
		 * Y = hover
		 */
		Vector2<std::string> images;
		images.x = button["images"]["original"].asString();
		images.y = button["images"]["hover"].asString();

		btn.setRenderer(renderer);
		btn.setTexture(images.x);
	}
}
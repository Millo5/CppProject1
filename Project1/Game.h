#pragma once

#include <iostream>

#include <SFML/Graphics.hpp>
#include <SFML/System.hpp>
#include <SFML/Window.hpp>
#include <SFML/Audio.hpp>
#include <SFML/Network.hpp>

/*
* Game Wrapper Class
*/
class Game
{
private:
	// Variables
	sf::RenderWindow* window;
	sf::VideoMode videoMode;
	sf::Event ev;
	//Map map;


	// Private Functions
	void InitVariables();
	void InitWindow();
	void InitGame();

public:
	// Constructors / Destructors
	Game();
	virtual ~Game();

	// Accessors
	const bool IsRunning() const;

	// Functions
	void PollEvents();
	void Update();
	void Render();
};

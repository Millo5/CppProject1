
#include "Game.h"
#include <iostream>



// Private Functions
void Game::InitVariables()
{
	window = nullptr;
}

void Game::InitWindow()
{
	videoMode.height = 900;
	videoMode.width = 1600;

	window = new sf::RenderWindow(videoMode, "Test");

	window->setFramerateLimit(120);
}

void Game::InitGame()
{

}

// Constructors / Destructors
Game::Game()
{
	InitVariables();
	InitWindow();
	InitGame();
}

Game::~Game()
{
	delete window;
}

// Accessors
const bool Game::IsRunning() const
{
	return window->isOpen();
}

// Functions
void Game::PollEvents()
{
	while (window->pollEvent(ev))
	{
		switch (ev.type)
		{
		case sf::Event::Closed:
			window->close();
			break;
		case sf::Event::KeyPressed:
			std::cout << "Key Pressed: " << ev.key.code;
			break;
		case sf::Event::KeyReleased:
			std::cout << "Key Released: " << ev.key.code;
			break;
		}
	}
}

void Game::Update()
{
	PollEvents();
	//std::cout << "Mouse Pos: " << sf::Mouse::getPosition(*window).x << " " << sf::Mouse::getPosition(*window).y << "\n";
	// sf::Keyboard::isKeyPressed(sf::Keyboard::A)
}

void Game::Render()
{
	window->clear();

	// draw game
	//window->draw(enemy);

	window->display();
}


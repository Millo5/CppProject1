#include "Game.h"

#pragma once
class Enemy
{
private:
	sf::Vector2f position;
	sf::RectangleShape shape;

	virtual void Update();

public:
	Enemy();
	virtual ~Enemy();

	void Update();
	void Render();
};


#include <SFML/Graphics.hpp>

#pragma once
class Ball
{
public:
	float x;
	float y;
	float xs;
	float ys;
	void Update();
	void Render(sf::RenderWindow window);
};


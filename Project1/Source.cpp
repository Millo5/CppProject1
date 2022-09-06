#include <iostream>
#include "Game.h"


int main()
{
	Game game;

	int width = 800;
	int height = 600;

	

	while (game.IsRunning())
	{
		// Update
		game.Update();

		// Render
		game.Render();
	}

	return 0;
}

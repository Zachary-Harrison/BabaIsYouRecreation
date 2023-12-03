# Baba Is You Recreation

- A basic recreation of the [Baba Is You](https://en.wikipedia.org/wiki/Baba_Is_You) video game based on the original Game Jam version's levels. A quick excerpt from its [Steam page](https://store.steampowered.com/app/736260/Baba_Is_You/):
    > Baba Is You is an award-winning puzzle game where you can change the rules by which you play. In every level, the rules themselves are present as blocks you can interact with; by manipulating them, you can change how the level works and cause surprising, unexpected interactions! With some simple block-pushing you can turn yourself into a rock, turn patches of grass into dangerously hot obstacles, and even change the goal you need to reach to something entirely different.
- Uses the C# Monogame framework and the Monogame.Extended open-source extension.
- A Visual Studio solution is included to view the code as well as build and run the game.
- It may be required to add the Monogame framework to Visual Studio.

## Quickstart

1. Clone the repository
   ```bash
   git clone https://github.com/Zachary-Harrison/BabaIsYouRecreation.git
   ```
2. `cd` into the appropriate directory
   ```bash
   cd BabaIsYouRecreation/Engine/bin/Release/net6.0/
   ```
3. Run the executable!
   ```bash
    ./Engine.exe
   ```



## Controls

- WASD - Menu Navigation, Default Movement
- Left/Right Arrow Keys - Menu Navigation
- Esc - Return to Menu, Pause(in game)
- Enter - Select
- Z - Undo (default)
- R - Reset Level (default)

## Features

- Players can edit the in-game keybindings, which will persist to local storage to be used each time the game is launched.
- An Undo Move mechanic is in place, allowing players to correct a wrong move.
- The level can be reset to its initial state at any time.
- Levels are constructed based on parsing an input file rather than hard coded. Additional levels can be added by editing said file.

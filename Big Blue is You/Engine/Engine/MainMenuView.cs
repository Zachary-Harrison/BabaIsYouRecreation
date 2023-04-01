﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Engine
{
    public class MainMenuView : GameStateView
    {
        private SpriteFont fontMenu;
        private SpriteFont fontMenuSelect;

        private enum MenuState
        {
            NewGame,
            HighScores,
            About,
            Quit
        }

        private MenuState currentSelection = MenuState.NewGame;
        private bool waitForKeyRelease = false;

        public override void loadContent(ContentManager contentManager)
        {
            fontMenu = contentManager.Load<SpriteFont>("Fonts/menu");
            fontMenuSelect = contentManager.Load<SpriteFont>("Fonts/menu-select");
        }
        public override GameStateEnum processInput(GameTime gameTime)
        {
            if (!waitForKeyRelease)
            {
                // Arrow keys to navigate the menu
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if ((int)currentSelection < 3)
                    {
                        currentSelection++;
                    }
                    waitForKeyRelease = true;

                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if ((int)currentSelection > 0)
                    {
                        currentSelection--;
                    }
                    waitForKeyRelease = true;
                }

                // If enter is pressed, return the appropriate new state
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentSelection == MenuState.NewGame)
                {
                    return GameStateEnum.GamePlay;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentSelection == MenuState.HighScores)
                {
                    return GameStateEnum.HighScores;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentSelection == MenuState.About)
                {
                    return GameStateEnum.About;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && currentSelection == MenuState.Quit)
                {
                    return GameStateEnum.Exit;
                }
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Enter))
            {
                waitForKeyRelease = false;
            }

            return GameStateEnum.MainMenu;
        }

        public override void update(GameTime gameTime)
        {
        }

        public override void render(GameTime gameTime)
        {
            spriteBatch.Begin();

            Vector2 stringSize = fontMenu.MeasureString("Engine");
            spriteBatch.DrawString(
                fontMenu,
                "Engine",
                new Vector2(graphics.PreferredBackBufferWidth / 2 - stringSize.X / 2, 100),
                Color.Blue);

            float bottom = drawMenuItem(
                currentSelection == MenuState.NewGame ? fontMenuSelect : fontMenu, 
                "New Game",
                400, 
                currentSelection == MenuState.NewGame ? Color.Yellow : Color.Blue);
            bottom = drawMenuItem(currentSelection == MenuState.HighScores ? fontMenuSelect : fontMenu, "High Scores", bottom, currentSelection == MenuState.HighScores ? Color.Yellow : Color.Blue);
            bottom = drawMenuItem(currentSelection == MenuState.About ? fontMenuSelect : fontMenu, "Credits", bottom, currentSelection == MenuState.About ? Color.Yellow : Color.Blue);
            drawMenuItem(currentSelection == MenuState.Quit ? fontMenuSelect : fontMenu, "Quit", bottom, currentSelection == MenuState.Quit ? Color.Yellow : Color.Blue);

            spriteBatch.End();
        }

        private float drawMenuItem(SpriteFont font, string text, float y, Color color)
        {
            Vector2 stringSize = font.MeasureString(text);
            spriteBatch.DrawString(
                font,
                text,
                new Vector2(graphics.PreferredBackBufferWidth / 2 - stringSize.X / 2, y),
                color);

            return y + stringSize.Y;
        }
    }
}
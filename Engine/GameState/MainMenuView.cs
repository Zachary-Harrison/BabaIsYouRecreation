using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Baba
{
    public class MainMenuView : GameStateView
    {
        private SpriteFont fontMenu;
        private SpriteFont fontMenuSelect;

        private enum MenuState
        {
            NewGame,
            Controls,
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
                if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if ((int)currentSelection < 3)
                    {
                        currentSelection++;
                    }
                    waitForKeyRelease = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if ((int)currentSelection > 0)
                    {
                        currentSelection--;
                    }
                    waitForKeyRelease = true;
                }

                // If enter is pressed, return the appropriate new state
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    waitForKeyRelease = true;
                    switch (currentSelection)
                    {
                        case MenuState.NewGame:
                            return GameStateEnum.LevelSelect;
                        case MenuState.Controls:
                            return GameStateEnum.Controls;
                        case MenuState.About:
                            return GameStateEnum.About;
                        case MenuState.Quit:
                            return GameStateEnum.Exit;
                        default: // This should be unreachable, but exit just in case
                            return GameStateEnum.Exit;
                    }
                }
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.Enter) &&
                Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Up))
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

            Vector2 stringSize = fontMenu.MeasureString("Baba is You!");
            spriteBatch.DrawString(
                fontMenu,
                "Baba is You!",
                new Vector2(graphics.PreferredBackBufferWidth / 2 - stringSize.X / 2, graphics.PreferredBackBufferHeight / 10),
                Color.Blue);

            float bottom = drawMenuItem(
                currentSelection == MenuState.NewGame ? fontMenuSelect : fontMenu, 
                "New Game",
                graphics.PreferredBackBufferHeight * 4 / 10, 
                currentSelection == MenuState.NewGame ? Color.Yellow : Color.Blue);
            bottom = drawMenuItem(currentSelection == MenuState.Controls ? fontMenuSelect : fontMenu, "Controls", bottom, currentSelection == MenuState.Controls ? Color.Yellow : Color.Blue);
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
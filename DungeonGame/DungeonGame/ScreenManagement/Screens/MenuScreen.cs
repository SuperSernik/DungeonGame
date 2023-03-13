using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.ScreenManagement.MenuItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonGame.ScreenManagement.Screens
{// this class creates the menu screen of the game.
    public class MenuScreen : UserScreen // inherits userscreen
    {
        // vars
        SpriteFont EngOldFont110;
        Texture2D Menu;
        Rectangle menuRectange;

        Vector2 titleRect;

        Texture2D player;
        Rectangle playerPos;

        ScreenButton playButton;
        ScreenButton quitButton;
        ScreenButton settingsButton;
            
        List<ScreenButton> btns = new List<ScreenButton>();

        public MenuScreen()
        {// sets the screen type to menu so that the screen manager can 
            // distinguish between screens
            screenType = "menu";
        }

        public override void LoadContent(ContentManager Content)
        {
            // loads content for all of the fonts and textures.
            base.LoadContent(Content); 
            EngOldFont110 = Content.Load<SpriteFont>("Fonts/EngOldFont110");
            Menu = Content.Load<Texture2D>("MenuScreens/VineBack");
            menuRectange = new Rectangle(0, 0, (int)ScreenManager.Instance.Resolution.X, (int)ScreenManager.Instance.Resolution.Y);
            player = Content.Load<Texture2D>("MiscImages/Jake320x480");
            
            playerPos = new Rectangle(2 * 32, 4 * 32, 500, 780);

            titleRect = new Vector2(19 * 32, 2 * 32 - 16);
            // centers all of the buttons on the screen of the menu
            playButton = new ScreenButton(new Vector2(800, 300), "Play Game", "play", "boxOne");
            btns.Add(playButton);
            quitButton = new ScreenButton(new Vector2(800, 600), "Quit", "quit", "boxOne");
            btns.Add(quitButton);
            settingsButton = new ScreenButton(new Vector2(800, 400), "Settings", "settings", "boxOne");
            btns.Add(settingsButton);
            settingsButton = new ScreenButton(new Vector2(800, 500), "Controls", "controls", "boxOne");
            btns.Add(settingsButton);
            foreach (ScreenButton button in btns) { button.LoadContent(Content); }

            switchToScreen = null;
            
        }
        public override void UnloadContent()
        {
            base.UnloadContent();


        }

        public override void Update(GameTime gameTime, Game1 g)
        {
            base.Update(gameTime);
            foreach (ScreenButton button in btns) 
            {
                button.Update(gameTime);

                // checks for the buttons on the menu to be pressed.
                if (button.buttonType == "play" && button.btnPressed == true)
                {
                    switchToScreen = "gameScreen";
                }
                if (button.buttonType == "settings" && button.btnPressed == true)
                {
                    switchToScreen = "settingsScreen";
                }
                if (button.buttonType == "quit" && button.btnPressed == true)
                {
                    g.Exit();
                }
                if (button.buttonType == "controls" && button.btnPressed == true)
                {
                    switchToScreen = "controlsDisplay";
                }

            }
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            // draws all of the items on the menu screen
            _spriteBatch.Begin();
            base.Draw(_spriteBatch);
            _spriteBatch.Draw(Menu, menuRectange, Color.White);
            _spriteBatch.DrawString(EngOldFont110, "Dark Dungeon", titleRect, Color.Wheat);
            _spriteBatch.Draw(player, playerPos, Color.Wheat);

            foreach (ScreenButton button in btns) { button.Draw(_spriteBatch); }
            _spriteBatch.End();
        }

    }
}


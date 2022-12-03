using DungeonGame.ScreenManagement.MenuItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ScreenManagement.Screens
{
    public class DisplayControlsScreen : UserScreen
    {

        Texture2D background;
        Rectangle backgroundRect;

        ScreenButton backButton;
        List<ScreenButton> ScreenBtns = new List<ScreenButton>();

        Texture2D controlsLayout;
        Rectangle controlsLayoutRect;

        public DisplayControlsScreen()
        {
            screenType = "controlsDisplay";
        }

        public override void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>("MenuScreens/VineBack");
            backgroundRect = new Rectangle(0, 0, (int)ScreenManager.Instance.Resolution.X, (int)ScreenManager.Instance.Resolution.Y);
            backButton = new ScreenButton(new Vector2(50, 50), "backToMenu", "cross");
            backButton.LoadContent(Content);
            ScreenBtns.Add(backButton);

            controlsLayout = Content.Load<Texture2D>("UserInterface/controls");
            controlsLayoutRect = new Rectangle((int)ScreenManager.Instance.Resolution.X/2 - controlsLayout.Width /2,
                (int)ScreenManager.Instance.Resolution.Y /2- controlsLayout.Height / 2,
                controlsLayout.Width,
                controlsLayout.Height);
        }
        public override void Update(GameTime gameTime)
        {
            foreach (ScreenButton button in ScreenBtns)
            {
                button.Update(gameTime);

                if (button.buttonType == "backToMenu" && button.btnPressed == true)
                {
                    switchToScreen = "menu";
                }
            }
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, backgroundRect, Color.White);

            _spriteBatch.Draw(controlsLayout, controlsLayoutRect, Color.White);

            foreach (ScreenButton button in ScreenBtns) { button.Draw(_spriteBatch); }
            _spriteBatch.End();
        }

    }
}

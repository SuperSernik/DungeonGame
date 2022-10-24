using DungeonGame.ScreenManagement;
using DungeonGame.ScreenManagement.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonGame.BackendDev
{
    class MouseManager
    {

        Rectangle mouseRect;
        Texture2D mouseTexture;
        Vector2 mousePosition;
        bool mousePressed;

        Rectangle sourceRect;

        public void LoadContent(ContentManager Content)
        {
            mouseTexture = Content.Load<Texture2D>("Cursors/Cursor");
            sourceRect = new Rectangle(0, 0, mouseTexture.Width, mouseTexture.Height);
            mousePressed = false;
        }
        public void Update(GameTime gameTime)
        {
            MouseState m = Mouse.GetState();
            mousePosition.X = m.Position.X;
            mousePosition.Y = m.Position.Y;

            mouseRect = new Rectangle((int)mousePosition.X, (int)mousePosition.Y, mouseTexture.Width / 2, mouseTexture.Height);

            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                mousePressed = true;
            }
            else
            {
                mousePressed = false;
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if(ScreenManager.Instance.currentScreen == ScreenManager.Instance.gameScreen)
            {
                ScreenManager.Instance.IsMOUSE_VISABLE = false;
                if (mousePressed)
                {
                    _spriteBatch.Draw(mouseTexture, mouseRect, new Rectangle(32, 0, 32, 32), Color.White);
                }
                else
                {
                    _spriteBatch.Draw(mouseTexture, mouseRect, new Rectangle(0, 0, 32, 32), Color.White);
                }

            }
            else
            {
                ScreenManager.Instance.IsMOUSE_VISABLE = true;

            }

            if (GameScreen.developerView)
            {
                _spriteBatch.Draw(DevTexturesManger.Instance.whiteBox1px, mouseRect, Color.Green);
            }

        }


    }
}

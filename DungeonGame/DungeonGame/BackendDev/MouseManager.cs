using DungeonGame.InventoryManagement;
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
        Texture2D mouseTexture;

        // Aimer Cursor
        Rectangle mouseRect;
        Vector2 mousePosition;
        bool mousePressed;
        Rectangle sourceRectNOTPressed, sourceRectPressed;

        //pointer cursor
        Rectangle pointerMouseRect;
        Vector2 pointerMousePosition;
        bool pointerMousePressed;
        Rectangle pointerSourceRectNOTPressed, pointerSourceRectPressed;




        public void LoadContent(ContentManager Content)
        {
            mouseTexture = Content.Load<Texture2D>("Cursors/Cursor");
            sourceRectNOTPressed = new Rectangle(0, 0, 32, 32);
            sourceRectPressed = new Rectangle(32, 0, 32, 32);
            mousePressed = false;

            pointerSourceRectNOTPressed = new Rectangle(0, 32, 32, 32);
            pointerSourceRectPressed = new Rectangle(32, 32, 32, 32);
            pointerMousePressed = false;

        }
        public void Update(GameTime gameTime)
        {
            MouseState m = Mouse.GetState();
            mousePosition.X = m.Position.X;
            mousePosition.Y = m.Position.Y;

            mouseRect = new Rectangle((int)mousePosition.X - sourceRectPressed.Width/2, (int)mousePosition.Y - sourceRectPressed.Height/2, sourceRectPressed.Width, sourceRectPressed.Height);

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
                ScreenManager.Instance.IsMOUSE_VISABLE = false; // CHANGE IF U WANT TO SEE MOUSE ON SCREEN IN GAME MODE

                if (!Inventory.invVisable)
                {
                    if (mousePressed)
                    {
                        _spriteBatch.Draw(mouseTexture, mouseRect, sourceRectPressed, Color.White);
                    }
                    else
                    {
                        _spriteBatch.Draw(mouseTexture, mouseRect, sourceRectNOTPressed, Color.White);
                    }
                }
                if (Inventory.invVisable)
                {
                    if (mousePressed)
                    {
                        _spriteBatch.Draw(mouseTexture, mouseRect, pointerSourceRectPressed, Color.White);
                    }
                    else
                    {
                        _spriteBatch.Draw(mouseTexture, mouseRect, pointerSourceRectNOTPressed, Color.White);
                    }
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

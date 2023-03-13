using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DungeonGame.BackendDev;
using DungeonGame.Entities;
using DungeonGame.MapManagement;
using DungeonGame.PlayerManagement;
using DungeonGame.ScreenManagement;
using DungeonGame.ScreenManagement.Screens;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonGame.Entities
{// creates the template for a button in game
    class InGameButton : Entity
    {
        // vars
        string buttonType;
        bool pressed;
        bool prevState;

        Texture2D buttonTextureAtlas;

        Rectangle buttonPressed;
        Rectangle buttonReleased;

        Rectangle buttonRECT;

        public InGameButton(string newButtonType, Vector2 position)
        {
            // sets position of button
            buttonType = newButtonType;
            buttonRECT = new Rectangle((int)position.X, (int)position.Y, 32, 32);
        }

        public override void LoadContent(ContentManager Content)
        {
            // depending on what button it is, it fetchs correct texture
            if(buttonType == "red")
            {
                buttonTextureAtlas = Content.Load<Texture2D>("Entities/gameButtonRED");
            }
            if(buttonType == "green")
            {
                buttonTextureAtlas = Content.Load<Texture2D>("Entities/gameButtonGREEN");
            }
            buttonReleased = new Rectangle(0, 0, 32, 32);
            buttonPressed = new Rectangle(32, 0, 32, 32);

            prevState = false;

        }
        // button animation logic 
        bool beingPressed = false;
        double timer = 0;
        int threshold = 150;
        public override void Update(GameTime gameTime, Player mainPlayer)
        {
                if (buttonRECT.Intersects(mainPlayer.playerCollisionBoxRect) &&Keyboard.GetState().IsKeyDown(Globals.useKey) && beingPressed == false)
                {
                    beingPressed = true;
                    if (pressed == false)
                    {
                        pressed = true;
                        if (buttonType == "red" && mainPlayer.playerHealth > 0)
                        {
                            mainPlayer.playerHealth--;
                        }

                        if (buttonType == "green" && mainPlayer.playerHealth < 10)
                        {
                            mainPlayer.playerHealth++;
                        }
                        timer = gameTime.ElapsedGameTime.TotalMilliseconds;
                    }         
                }
            if (timer > threshold)
            {
                if (!beingPressed)
                {
                    pressed = false;
                }
                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                beingPressed = false;
            }
        }


        public override void Draw(SpriteBatch _spriteBatch)
        {
            // draws the buttons to the screen (including the being presses animation)
            if (pressed)
            {
                _spriteBatch.Draw(buttonTextureAtlas, buttonRECT, buttonPressed, Color.White);
            }
            else
            {
                _spriteBatch.Draw(buttonTextureAtlas, buttonRECT, buttonReleased, Color.White);

            }

            if (GameScreen.developerView)
            {
                _spriteBatch.Draw(DevTexturesManger.Instance.whiteBox1px, buttonRECT, Color.Azure);
            }


        }
    }
}

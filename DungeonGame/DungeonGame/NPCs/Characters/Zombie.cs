using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using DungeonGame.BackendDev;
using MonoGame.Framework.Utilities.Deflate;
using DungeonGame.ScreenManagement;
using DungeonGame.ScreenManagement.Screens;

namespace DungeonGame.NPCs.Characters
{
    class Zombie : NPC // inherits from the NPC class
    {// the zombie class doest pretty much the same as the villager class
        // just that zombies always follow the players.

        // vars
        private Texture2D zombieTextureAtlas;
        private Rectangle[] zombieTexturesSourcRect;
        private Rectangle zombieRectangle;
        private Vector2 zombiePos;
        private float zombieVel;

        Line zL;

        public Zombie()
        {
            Random rn = new Random();
            int x = rn.Next(50);
            int y = rn.Next(30);    // creates a random spawn point for the zombie

            zombiePos = new Vector2(x * 32, y * 32);
            zombieRectangle = new Rectangle((int)zombiePos.X, (int)zombiePos.Y, 32, 48);
            zombieVel = 3f;
            // creates a line between the zombie and the player
            zL = new Line(zombiePos, new Vector2(ScreenManager.Instance.Resolution.X / 2, ScreenManager.Instance.Resolution.Y / 2));

        }

        public override void LoadContent(ContentManager Content)
        {// Load zombie texture atlas
            zombieTextureAtlas = Content.Load<Texture2D>("NPCTextures/zombieTextureAtlas");
            zombieTexturesSourcRect = new Rectangle[4];
            // Set the zombie texture source rectangles for different sta
            zombieTexturesSourcRect[0] = new Rectangle(0, 0, 32, 48);
            zombieTexturesSourcRect[1] = new Rectangle(32, 0, 32, 48);
            zombieTexturesSourcRect[2] = new Rectangle(64, 0, 32, 48);
            zombieTexturesSourcRect[3] = new Rectangle(96, 0, 32, 48);

            zL.LoadContent(Content);
        }

        public override void Update(GameTime gameTime, Rectangle playerRect)
        {
            // updates the zombies position
            zombiePos.X = Lerp(zombiePos.X, playerRect.X, 0.005f);
            zombiePos.Y = Lerp(zombiePos.Y, playerRect.Y, 0.005f);
            zombieRectangle = new Rectangle((int)zombiePos.X, (int)zombiePos.Y, 32, 48);

            zL.Update(gameTime, zombiePos, GameScreen.MainPlayer.playerPositionORIGIN);

            /*
            playerPos = Game1.PlayerPosition;
            zombiePos.X = 
            zombiePos.Y = 
            */

            //playerPos = Player.Instance.PlayerPosition;
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {// draws the zombie to the screen
            _spriteBatch.Draw(zombieTextureAtlas, zombieRectangle, zombieTexturesSourcRect[0], Color.White);
            if (GameScreen.developerView)
            {
                _spriteBatch.Draw(DevTexturesManger.Instance.whiteBox1px, zombieRectangle, Color.YellowGreen);
            }
            zL.Draw(_spriteBatch);
        }





        static float Lerp(float a, float b, float c)
        {
            // lerp stands for linear interpolation 
            // this creates a very smooth moving method for the zombie to use 
            // to move towards the player
            return a + (b - a) * c;
        }
        static Vector2 VectorLerp(Vector2 a, Vector2 b, float c)
        {
            Vector2 newV = new Vector2();

            newV.X = a.X + (b.X - b.Y) * c;
            newV.Y = a.Y + (b.Y - b.X) * c;

            return newV;

        }

        public void ZombieMove(string direction)
        {// moves zombie up, down, left , right
            if (direction == "up")
            {
                zombiePos.Y -= zombieVel;
            }

            if (direction == "down")
            {
                zombiePos.Y += zombieVel;
            }

            if (direction == "left")
            {
                zombiePos.X -= zombieVel;
            }

            if (direction == "right")
            {
                zombiePos.X += zombieVel;
            }

        }


    }
}

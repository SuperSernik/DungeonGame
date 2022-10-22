using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using DungeonGame.ScreenManagement;
using DungeonGame.PlayerManagement;
using DungeonGame.BackendDev;

namespace DungeonGame.Entities
{
    class Chest : Entity
    {
        // CHEST
        private Rectangle chestRectOpen;
        private Rectangle chestRectClosed;
        private Texture2D chestsTileMap;
        private Rectangle chestRectangle;


        private int row, col;                                                                                                                      
        private bool chestOpen;                                  



        public Chest(int NEWrow, int NEWcol)
        {

            row = NEWrow;
            col = NEWcol;

        }

        public override void LoadContent(ContentManager Content)
        {
            // Load tile map of chests
            chestsTileMap = Content.Load<Texture2D>("TileMaps/chestsTileMap");

            //chestMenuRectangle = new Rectangle(((int)ScreenManager.Instance.Resolution.X / 2) - (chestMenuTexture.Width / 2), ((int)ScreenManager.Instance.Resolution.Y / 2) - (chestMenuTexture.Height / 2), chestMenuTexture.Width, chestMenuTexture.Height);

            Random rn = new Random();
            int randNum = rn.Next(10); // Pick a random number
            // Get the closed chest texture from the chest texture atlas
            chestRectClosed = new Rectangle(randNum * 32, 0, 32, 32);
            // Get the open chest texture from the chest texture atlas
            chestRectOpen = new Rectangle(randNum * 32, 32, 32, 32);
            // Make sure the chest is closed when the game loads
            chestOpen = false;
            chestRectangle = new Rectangle(col * 32, row * 32, 32, 32);
        }



        public override void Update(GameTime gameTime, Player mainPlayer)
        {
            Logic l = new Logic();
            bool chestIsOpen = false;

            if (chestRectangle.Intersects(mainPlayer.playerCollisionBoxRect) && Keyboard.GetState().IsKeyDown(Keys.E))
            {
                if (chestIsOpen == false)
                {
                    chestOpen = true;
                    chestIsOpen = true;
                }
                if (chestIsOpen == true)
                {
                    chestOpen = false;
                    chestIsOpen = false;
                }



            }
            
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            if (chestOpen == true)
            {
                _spriteBatch.Draw(chestsTileMap, chestRectangle, chestRectOpen, Color.White);
                //_spriteBatch.Draw(chestMenuTexture, chestMenuRectangle, new Color(Color.White, 0.8f));

            }
            if (chestOpen == false)
            {
                _spriteBatch.Draw(chestsTileMap, chestRectangle, chestRectClosed, Color.White);

            }




        }




    }
}

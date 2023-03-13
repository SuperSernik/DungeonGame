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
using DungeonGame.ScreenManagement.Screens;
using DungeonGame.InventoryManagement;
using DungeonGame.ItemManagement.Items;

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
            this.type = "chest";

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


        bool addedItemFromThisChest = false;
        public override void Update(GameTime gameTime, Player mainPlayer)
        {
            bool chestIsOpen = false;
            // updates chest and checks if its open or not

            if (chestRectangle.Intersects(mainPlayer.playerCollisionBoxRect) && Keyboard.GetState().IsKeyDown(Globals.useKey))
            {
                if (chestIsOpen == false)
                {
                    chestOpen = true;

                    for(int i = 0; i < Inventory.itemsInHotBar.Length; i++)
                    {
                        if (Inventory.itemsInHotBar[i] == null && addedItemFromThisChest == false)
                        {
                            Random rn = new Random();
                            Inventory.itemsInHotBar[i] = ItemManager.listOfAllItems[rn.Next(ItemManager.listOfAllItems.Count)];
                            addedItemFromThisChest = true;
                        }
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (Inventory.itemsInInv[i,j] == null && addedItemFromThisChest == false)
                            {
                                // randomly rolls an item from the chest to give to the player
                                Random rn = new Random();
                                Inventory.itemsInInv[i,j] = ItemManager.listOfAllItems[rn.Next(ItemManager.listOfAllItems.Count)];
                                addedItemFromThisChest = true;
                            }
                        }

                    }


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

            if (GameScreen.developerView)
            {
                _spriteBatch.Draw(DevTexturesManger.Instance.whiteBox1px, chestRectangle, Color.Coral);
            }



        }




    }
}

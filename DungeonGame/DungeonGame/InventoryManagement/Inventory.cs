using DungeonGame.ScreenManagement;
using DungeonGame.BackendDev;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.ItemManagement.Items;
using DungeonGame.ScreenManagement.Screens;
using DungeonGame.ScreenManagement.Overlays;

namespace DungeonGame.InventoryManagement
{
    class Inventory
    {
        // ITEM DATA
        Texture2D weaponsAtlas, foodsAtlas;

        // INV DATA
        Rectangle[,] invSlots;
        public static Item[,] itemsInInv;

        // HOT BAR DATA
        Rectangle[] hotbarSlots;
        public static Item[] itemsInHotBar;
        public int currentSlot;

        // DRAWING THE INVENTORY
        Rectangle invLayout;
        int invTextWidth, invTextHeight;
        float invsf;
        Rectangle invTextureVisableSize;
        Rectangle invSourceRect;
        public static bool invVisable;

        
        // DRAWING THE HOTBAR
        Rectangle hotbarLayout;
        int hotBarTextWidth, hotBarTextHight;
        float hotBarsf;
        Rectangle hotBarTextureVisableSize;
        Rectangle hotBarSourceRect;
        
        // UI TEXTURES
        Texture2D UIAtlas;
        Texture2D atlasThatContainItemsToDraw;

        // INV MOVING SELECTOR
        Rectangle selectorSourceRect;
        public Rectangle selectorPosRect;
        int prevScrollValue;

        public void LoadContent(ContentManager Content)
        {
            //Items
            weaponsAtlas = Content.Load<Texture2D>("Weapons/weaponsAtlas");
            foodsAtlas = Content.Load<Texture2D>("Items/foodsAtlas");
            // UI TEXTURES
            UIAtlas = Content.Load<Texture2D>("UserInterface/InventoryUI");

            // INVENTORY
            invVisable = false;
            invTextWidth = 320;
            invTextHeight = 160;
            invsf = 1.6f;

            invSourceRect = new Rectangle(0, 224, invTextWidth, invTextHeight);                                         // IN TEXTURE
            invTextureVisableSize = new Rectangle(0, 0, (int)(invTextWidth * invsf), (int)(invTextHeight * invsf));     // IN GAME
            invLayout = new Rectangle(((int)ScreenManager.Instance.Resolution.X / 2) - invTextureVisableSize.Width / 2, ((int)ScreenManager.Instance.Resolution.Y) - (int)(invTextureVisableSize.Height * 1.4), invTextureVisableSize.Width, invTextureVisableSize.Height);

            //inv slots
            invSlots = new Rectangle[3, 6];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    invSlots[i, j] = new Rectangle(invLayout.X + (83 * j) + 15, invLayout.Y + (83 * i) + 12, 70, 70);
                    invSlots[i, j].X += 2;
                    invSlots[i, j].Y += 2;
                    invSlots[i, j].Width-=8;
                    invSlots[i, j].Height-=8;
                }
            }

            // inv items
            itemsInInv = new Item[3,6];
            itemsInInv[0,0] = ItemManager.banana;
            itemsInInv[0,5] = ItemManager.pistol;
            itemsInInv[2,0] = ItemManager.bazooka;
            itemsInInv[2,5] = ItemManager.pp;
            itemsInInv[1,3] = ItemManager.nyanLauncher;
            itemsInInv[1,2] = ItemManager.nyanLauncher;



            // HOT BAR
            hotBarTextWidth = 224;
            hotBarTextHight = 64;
            hotBarsf = 1.4f;

            hotBarSourceRect = new Rectangle(224, 0, hotBarTextWidth, hotBarTextHight);                                               // IN TEXTURE
            hotBarTextureVisableSize = new Rectangle(0, 0, (int)(hotBarTextWidth * hotBarsf), (int)(hotBarTextHight * hotBarsf));     // IN GAME
            hotbarLayout = new Rectangle(((int)ScreenManager.Instance.Resolution.X / 2) - hotBarTextureVisableSize.Width / 2, ((int)ScreenManager.Instance.Resolution.Y) - hotBarTextureVisableSize.Height, hotBarTextureVisableSize.Width, hotBarTextureVisableSize.Height);

            selectorSourceRect = new Rectangle(224, 64, 64, 64);                    // IN TEXTURE
            selectorPosRect = new Rectangle(hotbarLayout.X, hotbarLayout.Y, (int)(64 * hotBarsf), (int)(64 * hotBarsf));      // IN GAME
            currentSlot = 0;

            //hotbar slots
            hotbarSlots = new Rectangle[4];
            for(int i = 0; i < hotbarSlots.Length; i++)
            {
                hotbarSlots[i] = new Rectangle(hotbarLayout.X + (70 * i) + 15, hotbarLayout.Y + 12, 70, 70);
                hotbarSlots[i].X += 10;
                hotbarSlots[i].Y += 10;
                hotbarSlots[i].Width -= 20;
                hotbarSlots[i].Height -= 20;

            }

            // hotbar items
            itemsInHotBar = new Item[4];
            itemsInHotBar[0] = ItemManager.pistol;
            itemsInHotBar[1] = ItemManager.nyanLauncher;
            itemsInHotBar[2] = ItemManager.bazooka;
            //itemsInHotBar[3] = ItemManager.cake;


        }

        public void Update(GameTime gameTime)
        {
            ScrollThroughHotbar();
            switchPlayerItem();
            dropItem();
            displayInventory();

        }




        public void Draw(SpriteBatch _spriteBatch)
        {
            //hot bar casing
            _spriteBatch.Draw(UIAtlas, hotbarLayout, hotBarSourceRect, Color.White);


            if (invVisable)
            {
                // inventory casing
                _spriteBatch.Draw(UIAtlas, invLayout, invSourceRect, Color.White);


                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {

                        if (itemsInInv[i, j] != null)
                        {
                            if (itemsInInv[i, j].itemType == "weapon")
                            {
                                atlasThatContainItemsToDraw = weaponsAtlas;
                            }
                            if (itemsInInv[i, j].itemType == "food")
                            {
                                atlasThatContainItemsToDraw = foodsAtlas;
                            }
                            _spriteBatch.Draw(atlasThatContainItemsToDraw, invSlots[i, j], itemsInInv[i, j].sourceRect, Color.White);
                        }


                        if (GameScreen.developerView)
                        {
                            _spriteBatch.Draw(DevTexturesManger.Instance.whiteBox1px, invSlots[i, j], Color.Red);

                        }

                    }
                }
                
            }





            DrawHotBarWithItems(_spriteBatch);

        }


        // ############################################## METHODS ################################################################################

        void DrawHotBarWithItems(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < itemsInHotBar.Length; i++) // HOTBAR
            {

                if (itemsInHotBar[i] != null)
                {
                    if (itemsInHotBar[i].itemType == "weapon")
                    {
                        atlasThatContainItemsToDraw = weaponsAtlas;
                    }
                    if (itemsInHotBar[i].itemType == "food")
                    {
                        atlasThatContainItemsToDraw = foodsAtlas;
                    }
                    _spriteBatch.Draw(atlasThatContainItemsToDraw, hotbarSlots[i], itemsInHotBar[i].sourceRect, Color.White);
                }
                if (GameScreen.developerView)
                {
                    _spriteBatch.Draw(DevTexturesManger.Instance.whiteBox1px, hotbarSlots[i], Color.Red);
                }
            }


            _spriteBatch.Draw(UIAtlas, selectorPosRect, selectorSourceRect, Color.White); // Hotbar selector
        }

        void ScrollThroughHotbar()
        {
            MouseState mouse = Mouse.GetState();

            if (mouse.ScrollWheelValue > prevScrollValue)
            {
                if (selectorPosRect.X > hotbarLayout.X)
                {
                    selectorPosRect.X -= 70;
                    currentSlot--;
                }

            }
            else if (mouse.ScrollWheelValue < prevScrollValue)
            {
                if (selectorPosRect.X < hotbarLayout.X + 70 * 3)
                {
                    selectorPosRect.X += 70;
                    currentSlot++;

                }
            }
            prevScrollValue = mouse.ScrollWheelValue;
        }


        void dropItem()
        {
            if (Keyboard.GetState().IsKeyDown(Globals.dropItemKey))
            {
                itemsInHotBar[currentSlot] = null;
            }
        }
        public void switchPlayerItem()
        {
            GameScreen.MainPlayer.CurrentItemHeld = itemsInHotBar[currentSlot];
        }


        // INCLUDE WHEN MOVING DIS
        bool beingPressed = false;
        void displayInventory()
        {
            if (Keyboard.GetState().IsKeyDown(Globals.inventoryKey) && beingPressed == false)
            {
                beingPressed = true;
                if (invVisable == false)
                {
                    invVisable = true;
                }
                else if (invVisable == true)
                {
                    invVisable = false;

                }
            }

            if (Keyboard.GetState().IsKeyUp(Globals.inventoryKey))
            {
                beingPressed = false;
            }
        }

    }
}

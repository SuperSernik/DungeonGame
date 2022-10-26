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
        Item[,] itemsInInv = new Item[4, 2];

        // HOT BAR DATA
        Rectangle[] hotbarSlots;
        public static Item[] itemsInHotBar;

        public int currentSlot;

        // DRAWING THE INV
        Texture2D UIAtlas;
        Rectangle invLayout;
        int textWidth, textHight;
        float sf;
        Rectangle textureVisableSize;
        Rectangle sourceRect;
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
            // INV
            UIAtlas = Content.Load<Texture2D>("UserInterface/InventoryUI");

            textWidth = 224;
            textHight = 64;
            sf = 1.4f;

            sourceRect = new Rectangle(224, 0, textWidth, textHight);                                   // IN TEXTURE
            textureVisableSize = new Rectangle(0, 0, (int)(textWidth * sf), (int)(textHight * sf));     // IN GAME
            invLayout = new Rectangle(((int)ScreenManager.Instance.Resolution.X / 2) - textureVisableSize.Width / 2, ((int)ScreenManager.Instance.Resolution.Y) - textureVisableSize.Height, textureVisableSize.Width, textureVisableSize.Height);

            selectorSourceRect = new Rectangle(224, 64, 64, 64);                    // IN TEXTURE
            selectorPosRect = new Rectangle(invLayout.X, invLayout.Y, (int)(64 * sf), (int)(64 * sf));      // IN GAME
            currentSlot = 0;


            hotbarSlots = new Rectangle[4];
            for(int i = 0; i < 4; i++)
            {
                hotbarSlots[i] = new Rectangle(invLayout.X + (70 * i) + 15, invLayout.Y + 12, 70, 70);
                hotbarSlots[i].X += 10;
                hotbarSlots[i].Y += 10;
                hotbarSlots[i].Width -= 20;
                hotbarSlots[i].Height -= 20;

            }

            itemsInHotBar = new Item[4];


            itemsInHotBar[0] = ItemManager.pistol;
            itemsInHotBar[1] = ItemManager.nyanLauncher;
            itemsInHotBar[2] = ItemManager.bazooka;
            itemsInHotBar[3] = ItemManager.cake;


        }

        public void Update(GameTime gameTime)
        {
            ScrollThroughHotbar();
            switchPlayerItem();

            if (Keyboard.GetState().IsKeyDown(Globals.dropItemKey))
            {
                itemsInHotBar[currentSlot] = null;
            }


        }


        public void switchPlayerItem()
        {
            GameScreen.MainPlayer.CurrentItemHeld = itemsInHotBar[currentSlot];
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(UIAtlas, invLayout, sourceRect, Color.White);

            for (int i = 0; i < 4; i++)
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








            _spriteBatch.Draw(UIAtlas, selectorPosRect, selectorSourceRect, Color.White);




        }

        void ScrollThroughHotbar()
        {
            MouseState mouse = Mouse.GetState();

            if (mouse.ScrollWheelValue > prevScrollValue)
            {
                if (selectorPosRect.X > invLayout.X)
                {
                    selectorPosRect.X -= 70;
                    currentSlot--;
                }

            }
            else if (mouse.ScrollWheelValue < prevScrollValue)
            {
                if (selectorPosRect.X < invLayout.X + 70 * 3)
                {
                    selectorPosRect.X += 70;
                    currentSlot++;

                }
            }
            prevScrollValue = mouse.ScrollWheelValue;
        }

        void quickWeaponSwitch()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                //GameScreen.MainPlayer.CurrentWeapon = ItemManager.pistol;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                //GameScreen.MainPlayer.CurrentWeapon = ItemManager.nyanLauncher;
            }
        }
    }
}

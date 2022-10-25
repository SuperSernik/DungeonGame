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

namespace DungeonGame.InventoryManagement
{
    class Inventory
    {
        // WEAPON DATA
        Texture2D weaponsAtlas;

        // INV DATA
        Item[,] itemsInInv = new Item[4, 3];

        // HOT BAR DATA
        Rectangle[] hotbarSlots;

        // DRAWING THE INV
        Texture2D UIAtlas;
        Rectangle invLayout;
        int textWidth, textHight;
        float sf;
        Rectangle textureVisableSize;
        Rectangle sourceRect;

        // INV MOVING SELECTOR
        Rectangle selectorSourceRect;
        public Rectangle selectorPosRect;
        int prevScrollValue;

        public void LoadContent(ContentManager Content)
        {
            //Weapons
            weaponsAtlas = Content.Load<Texture2D>("Weapons/weaponsAtlas");

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


            hotbarSlots = new Rectangle[4];
            for(int i = 0; i < 4; i++)
            {
                hotbarSlots[i] = new Rectangle(invLayout.X + (70 * i) + 15, invLayout.Y + 12, 70, 70);
                hotbarSlots[i].X += 10;
                hotbarSlots[i].Y += 10;
                hotbarSlots[i].Width -= 20;
                hotbarSlots[i].Height -= 20;

            }


        }

        public void Update(GameTime gameTime)
        {
            ScrollThroughHotbar();


        }


        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(UIAtlas, invLayout, sourceRect, Color.White);

            for (int i = 0; i < 4; i++)
            {
                _spriteBatch.Draw(DevTexturesManger.Instance.whiteBox1px, hotbarSlots[i], Color.Red);
                _spriteBatch.Draw(weaponsAtlas, hotbarSlots[i], ItemManager.gun.sourceRect, Color.White);
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
                }

            }
            else if (mouse.ScrollWheelValue < prevScrollValue)
            {
                if (selectorPosRect.X < invLayout.X + 70 * 3)
                {
                    selectorPosRect.X += 70;

                }
            }
            prevScrollValue = mouse.ScrollWheelValue;
        }
    }
}

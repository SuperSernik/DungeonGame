using DungeonGame.InventoryManagement;
using DungeonGame.ItemManagement.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.BackendDev
{
    // this class is for when you need to drawn something to help with debugging
    // but you dont want to keep it in the final game.
    class DrawCheck
    {
        // Sets variables
        Texture2D texture;
        SpriteFont spriteFont;

        Vector2 position;

        Rectangle sourceRect;
        int prev;
        Color colorr;

        public void LoadContent(ContentManager Content)
        {// laods textures
            texture = Content.Load<Texture2D>("Weapons/weaponsAtlas");
            spriteFont = Content.Load<SpriteFont>("Fonts/Arial32");
            sourceRect = new Rectangle(0, 32, 320, 64);
            position = new Vector2(100, 100);
            colorr = Color.White;
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            // updates the values of whats being drawn to the screen

            if(mouse.ScrollWheelValue > prev)
            {
                colorr = Color.Turquoise;
            }
            else if (mouse.ScrollWheelValue < prev)
            {
                colorr = Color.Red;
            }
            prev = mouse.ScrollWheelValue;


        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            //_spriteBatch.Draw(texture, position, sourceRect, Color.White);
            //_spriteBatch.DrawString(spriteFont, Convert.ToString(prev), position, colorr);
            //_spriteBatch.DrawString(spriteFont, Convert.ToString(InventoryManager.inv.selectorPosRect.X), position, colorr);

            // draws textures
            _spriteBatch.DrawString(spriteFont, Convert.ToString(ItemManager.pp.angleOfLine), position, colorr);

        }

    }
}

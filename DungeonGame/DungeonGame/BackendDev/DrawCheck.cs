using DungeonGame.InventoryManagement;
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
    class DrawCheck
    {

        Texture2D texture;
        SpriteFont spriteFont;

        Vector2 position;

        Rectangle sourceRect;
        int prev;
        Color colorr;

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Weapons/weaponsAtlas");
            spriteFont = Content.Load<SpriteFont>("Fonts/Arial32");
            sourceRect = new Rectangle(0, 32, 320, 64);
            position = new Vector2(100, 100);
            colorr = Color.White;
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

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
            _spriteBatch.DrawString(spriteFont, Convert.ToString(InventoryManager.inv.selectorPosRect.X), position, colorr);
        }

    }
}

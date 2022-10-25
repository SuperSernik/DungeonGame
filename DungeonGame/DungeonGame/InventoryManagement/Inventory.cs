using DungeonGame.ScreenManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.InventoryManagement
{
    class Inventory
    {
        Texture2D UIAtlas;
        Rectangle invLayout;
        int textWidth, textHight;
        float sf;

        Rectangle textureVisableSize;

        Rectangle sourceRect;

        public void LoadContent(ContentManager Content)
        {
            textWidth = 224;
            textHight = 64;
            sf = 1.4f;


            UIAtlas = Content.Load<Texture2D>("UserInterface/InventoryUI");
            sourceRect = new Rectangle(224, 0, textWidth, textHight); 

            textureVisableSize = new Rectangle(0, 0, (int)(textWidth * sf), (int)(textHight * sf));


            invLayout = new Rectangle(((int)ScreenManager.Instance.Resolution.X / 2) - textureVisableSize.Width / 2, ((int)ScreenManager.Instance.Resolution.Y) - textureVisableSize.Height, textureVisableSize.Width, textureVisableSize.Height);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(UIAtlas, invLayout, sourceRect, Color.White);


        }


    }
}

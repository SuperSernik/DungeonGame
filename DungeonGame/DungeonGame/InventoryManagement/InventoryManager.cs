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
    class InventoryManager
    {
        public static Inventory inv = new Inventory();

        public void LoadContent(ContentManager Content)
        {
            inv.LoadContent(Content);
        }

        public void Update(GameTime gameTime)
        {
            inv.Update(gameTime);

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            inv.Draw(_spriteBatch);

        }



    }
}

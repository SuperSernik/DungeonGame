using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.InventoryManagement
{// mangages the players inventory
    class InventoryManager
    {
        // creates the inventory
        public static Inventory inv = new Inventory();     
        public void LoadContent(ContentManager Content)
        {// loads textures, items etc
            inv.LoadContent(Content);
        }
        public void Update(GameTime gameTime)
        {// updates  moving values etc
            inv.Update(gameTime);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {// draws inventory
            inv.Draw(_spriteBatch);
        }



    }
}

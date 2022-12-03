using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ItemManagement.Items
{
    public class Item
    {

        public string itemType, itemName;
        public Rectangle sourceRect;
        public bool isHolding;

        public Item(string newItemType, string newItemName)
        {
            itemType = newItemType;
            itemName = newItemName;
        }


        public virtual void LoadContent(ContentManager content) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Update(GameTime gameTime, Vector2 pos) { }
        public virtual void Draw(SpriteBatch _spriteBatch) { }


    }
}

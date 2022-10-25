using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame_v2.ItemManagement.Items
{
    class Item
    {

        /// <summary>
        /// Items#  weapons, food, potions, ammunuition
        /// 
        /// </summary>

        private string itemType, itemName;

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

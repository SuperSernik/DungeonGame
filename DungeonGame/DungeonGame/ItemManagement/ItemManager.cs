using DungeonGame.PlayerManagement;
using DungeonGame_v2.ItemManagement.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame_v2.ItemManagement
{
    class ItemManager
    {


        Weapon gun = new Weapon("weapon", "pistol", 0);


        public void LoadContent(ContentManager content)
        {
            gun.LoadContent(content);
        }

        public void Update(GameTime gameTime, Player p)
        {
            gun.Update(gameTime, p.playerPositionORIGIN);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            gun.Draw(_spriteBatch);

        }



    }
}

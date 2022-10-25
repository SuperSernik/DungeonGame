using DungeonGame.PlayerManagement;
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
    class ItemManager
    {



        public static Weapon gun = new Weapon("weapon", "pistol", 0);


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

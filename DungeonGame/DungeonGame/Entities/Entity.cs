using DungeonGame.PlayerManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Entities
{
    abstract class Entity
    {
        

        public virtual void LoadContent(ContentManager Content) { }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Update(GameTime gameTime, Rectangle rect) { }
        public virtual void Update(GameTime gameTime, Player player) { }

        public virtual void Update(GameTime gameTime, Rectangle rect, int ammountOfPlyerCoins) { }

        public virtual void Draw(SpriteBatch _spriteBatch) { }



    }
}

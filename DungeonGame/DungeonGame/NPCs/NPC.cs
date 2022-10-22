using DungeonGame.PlayerManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.NPCs
{
    public class NPC
    {
        public virtual void LoadContent(ContentManager Content) { }

        public virtual void Update(GameTime gameTime) { }
        // Overloaded method
        public virtual void Update(GameTime gameTime, Rectangle rect) { }
        public virtual void Update(GameTime gameTime, Player player) { }


        public virtual void Draw(SpriteBatch _spriteBatch) { }


    }
}

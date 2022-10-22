using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ScreenManagement.Overlays
{
    public class SuperOverlay
    {

        public virtual void LoadContent(ContentManager content) { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch _spriteBatch) { }

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.BackendDev
{
    class DrawCheck
    {

        Texture2D texture;
        Vector2 position;

        Rectangle sourceRect;

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Weapons/weaponsAtlas");
            sourceRect = new Rectangle(0, 32, 320, 64);
            position = new Vector2(100, 100);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, position, sourceRect, Color.White);
        }

    }
}

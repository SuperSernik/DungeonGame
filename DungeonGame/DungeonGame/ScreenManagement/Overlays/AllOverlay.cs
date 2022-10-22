using DungeonGame.PlayerManagement;
using DungeonGame.ScreenManagement.Screens;
using DungeonGame.ScreenManagement.ScreenStats;
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
    public class AllOverlay : SuperOverlay
    {

        StatsDisplay std = new StatsDisplay();

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            std.LoadContent(content);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            std.Update(gameTime);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
            std.Draw(_spriteBatch);
        }



    }
}

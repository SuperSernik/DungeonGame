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
using DungeonGame.BackendDev;

namespace DungeonGame.ScreenManagement.Overlays
{
    public class AllOverlay : SuperOverlay
    {

        StatsDisplay std = new StatsDisplay();
        MouseManager mm = new MouseManager();

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            std.LoadContent(content);
            mm.LoadContent(content);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            std.Update(gameTime);
            mm.Update(gameTime);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
            std.Draw(_spriteBatch);
            mm.Draw(_spriteBatch);  
        }



    }
}

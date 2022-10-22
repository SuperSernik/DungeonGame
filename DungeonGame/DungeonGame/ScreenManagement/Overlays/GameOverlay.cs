using DungeonGame.PlayerManagement;
using DungeonGame.ScreenManagement.Screens;
using DungeonGame.ScreenManagement.ScreenStats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ScreenManagement.Overlays
{
    class GameOverlay : SuperOverlay
    {

        PlayerInfoDisplay pid = new PlayerInfoDisplay();


        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            pid.LoadContent(content, GameScreen.MainPlayer);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            pid.Update(gameTime, GameScreen.MainPlayer);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
            pid.Draw(_spriteBatch);
        }


        
    }
}

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
{// this class compiles all of the overlays that can be seen 
    // all the way throughout the program, on loading screens, menu, game screen etc.
    public class AllOverlay : SuperOverlay // inherits SuperOverlay
    {

        StatsDisplay std = new StatsDisplay(); // creates a stats display instance
        MouseManager mm = new MouseManager();   // creates a mouse manager instance

        public override void LoadContent(ContentManager content)
        {// loads content that the overlays need to work
            base.LoadContent(content);
            std.LoadContent(content);
            mm.LoadContent(content);

        }

        public override void Update(GameTime gameTime)
        {// updates any changing values
            base.Update(gameTime);
            std.Update(gameTime);
            mm.Update(gameTime);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {// draws the overlays to the screen
            base.Draw(_spriteBatch);
            std.Draw(_spriteBatch);
            mm.Draw(_spriteBatch);  
        }



    }
}

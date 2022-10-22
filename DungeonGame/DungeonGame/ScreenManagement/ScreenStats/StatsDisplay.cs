using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonGame.ScreenManagement.ScreenStats
{
    public class StatsDisplay
    {
        // Atrributes
        SpriteFont Arial16;
        Vector2 fpsPos;
        string fps;
        string memory;
        Vector2 memPos;

        public void LoadContent(ContentManager Content)
        {
            Arial16 = Content.Load<SpriteFont>("Fonts/Arial16");
            fpsPos = new Vector2(ScreenManager.Instance.Resolution.X - 120, ScreenManager.Instance.Resolution.Y - 60);  // Sets the position 910
            memPos = new Vector2(ScreenManager.Instance.Resolution.X - 120, ScreenManager.Instance.Resolution.Y - 30); // of where i want the data to be. 930
        }
        public void Update(GameTime gameTime)
        {
            // This gets the fps from 1 divided by the total elaped time in second. I also make sure i display
            // it in the correct format which is up to 1 decimal place.
            fps = Convert.ToString($"Fps:{1 / (float)gameTime.ElapsedGameTime.TotalSeconds:00.0}");
            // I use the Process class to retrieve the ammount of memory used.
            Process proc = Process.GetCurrentProcess();
            //  Here i also set is so that i can only see it up to 1 decimal place and so that is shown in megabytes.
            memory = Convert.ToString($"Mem:{proc.PrivateMemorySize64/1024/1024:00.0}");
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            // I draw both of the values to the screen.
            _spriteBatch.DrawString(Arial16, fps, fpsPos, Color.White);
            _spriteBatch.DrawString(Arial16, memory, memPos, Color.White);

        }

    }
}

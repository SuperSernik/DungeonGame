using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;

namespace DungeonGame.ScreenManagement
{// superclass for other classes to inherit from 
    public class UserScreen
    {
        protected ContentManager Content;
        public bool switchScreens;
        public string screenType;
        public string switchToScreen;

        public virtual void LoadContent(ContentManager Content)
        {
            /*
              content = new ContentManager(
                ScreenManager.Instance.Content.ServiceProvider, "Content");
             
            Content = new ContentManager(Content.ServiceProvider, Content.RootDirectory);
            */
        }
        public virtual void UnloadContent()
        {
            Content.Unload();
        }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Update(GameTime gameTime, Game1 game1) { }
        public virtual void Draw(SpriteBatch _spriteBatch) { }



    }
}

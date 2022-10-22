using DungeonGame.ScreenManagement.Overlays;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ScreenManagement.Screens
{
    public class OverlayManager
    {
        private static OverlayManager instance;
        public ContentManager Content { private set; get; }
        public SpriteBatch _spriteBatch;

        SuperOverlay AccGameOverlay, AccAllOverlay;
        

        public static OverlayManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new OverlayManager();
                return instance;
            }
        }

        public void LoadContent(ContentManager content)
        {
            AccGameOverlay = new GameOverlay();
            AccAllOverlay = new AllOverlay();

            AccGameOverlay.LoadContent(content);
            AccAllOverlay.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            AccGameOverlay.Update(gameTime);
            AccAllOverlay.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            if(ScreenManager.Instance.currentScreen == ScreenManager.Instance.gameScreen)
            {
                AccGameOverlay.Draw(_spriteBatch);
            }

            AccAllOverlay.Draw(_spriteBatch);
            _spriteBatch.End();
        }


    }
}

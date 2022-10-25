using DungeonGame.BackendDev;
using DungeonGame.InventoryManagement;
using DungeonGame.PlayerManagement;
using DungeonGame.ScreenManagement.Screens;
using DungeonGame.ScreenManagement.ScreenStats;
using DungeonGame.ItemManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.ItemManagement.Items;

namespace DungeonGame.ScreenManagement.Overlays
{
    class GameOverlay : SuperOverlay
    {

        PlayerInfoDisplay pid = new PlayerInfoDisplay();
        ItemManager im = new ItemManager();
        InventoryManager invM = new InventoryManager();

        Line pL = new Line(new Vector2(ScreenManager.Instance.Resolution.X / 2, (ScreenManager.Instance.Resolution.Y / 2) + 15), Vector2.Zero, GameScreen.developerView, Color.Turquoise);


        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            pid.LoadContent(content, GameScreen.MainPlayer);
            pL.LoadContent(content);
            im.LoadContent(content);
            invM.LoadContent(content);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            pid.Update(gameTime, GameScreen.MainPlayer);
            pL.Update(gameTime, GameScreen.MainPlayer);
            im.Update(gameTime, GameScreen.MainPlayer);
            invM.Update(gameTime);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
            pid.Draw(_spriteBatch);
            pL.Draw(_spriteBatch);
            im.Draw(_spriteBatch);
            invM.Draw(_spriteBatch);

        }



    }
}

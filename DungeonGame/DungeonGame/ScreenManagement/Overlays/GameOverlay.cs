﻿using DungeonGame.BackendDev;
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
using DungeonGame.ItemManagement.NonItemItems;

namespace DungeonGame.ScreenManagement.Overlays
{// this class compiles all of the overlays that are displayed on the game screen
    class GameOverlay : SuperOverlay // inherits superOverlay
    {

        PlayerInfoDisplay pid = new PlayerInfoDisplay();    // hearts, coins etc
        public static ItemManager im = new ItemManager();   // items in the hand
        public InventoryManager invM = new InventoryManager();// inventory

        BulletManager bulletM = new BulletManager(); // bullets

        Line pL = new Line(new Vector2(ScreenManager.Instance.Resolution.X / 2,
            (ScreenManager.Instance.Resolution.Y / 2) + 15),
            Vector2.Zero,
            GameScreen.developerView, Color.Turquoise);


        public override void LoadContent(ContentManager content)
        {
            // loads all of the content for all of the overlays  
            base.LoadContent(content);
            pid.LoadContent(content, GameScreen.MainPlayer);
            pL.LoadContent(content);
            im.LoadContent(content);
            invM.LoadContent(content);
            bulletM.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {// updates any changing values in the overlays such as ammout of coins in the pid
            base.Update(gameTime);
            pid.Update(gameTime, GameScreen.MainPlayer);
            pL.Update(gameTime, GameScreen.MainPlayer);
            im.Update(gameTime, GameScreen.MainPlayer);
            invM.Update(gameTime);

            bulletM.Update();
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {// draws the items in the overlay
            base.Draw(_spriteBatch);
            bulletM.Draw();
            pid.Draw(_spriteBatch);
            pL.Draw(_spriteBatch);
            im.Draw(_spriteBatch);
            invM.Draw(_spriteBatch);


        }



    }
}

using DungeonGame.ScreenManagement.Screens;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DungeonGame.ItemManagement.NonItemItems
{
    public class BulletManager
    {

        List<Bullet> bullets = new List<Bullet>();

        Vector2 mousePos;
        Vector2 playerPos;

        float timeBetweenShots;
        float timer = 0;

        //Vector2 playerPosition = new Vector2(ScreenManager.Instance.Resolution.X / 2, ScreenManager.Instance.Resolution.Y / 2 / 2 + 15);

        Vector2 playerPosition = new Vector2(Globals._graphics.PreferredBackBufferWidth / 2, Globals._graphics.PreferredBackBufferHeight / 2 + 15); 
        // add 15 for distance between player and the gun


        public void LoadContent()
        {

        }

        public void Update()
        {
            if(GameScreen.MainPlayer.CurrentItemHeld != null)
            {
                if (GameScreen.MainPlayer.CurrentItemHeld.itemName == "pistol")
                {
                    shootPistol(playerPosition);
                }

                if (GameScreen.MainPlayer.CurrentItemHeld.itemName == "bazooka")
                {
                    shootBazooka(playerPosition);
                }
            }



            foreach (var x in bullets)
            {
                x.Update();
            }

        }

        public void Draw()
        {
            foreach (var x in bullets)
            {
                x.Draw();
            }
        }

        void shootPistol(Vector2 playerPos)
        {
            timeBetweenShots = 100;

            mousePos.X = Mouse.GetState().Position.X - playerPos.X;
            mousePos.Y = Mouse.GetState().Position.Y - playerPos.Y;


            if (timer > timeBetweenShots && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {

                Bullet a = new Bullet(playerPos, mousePos, "small", 25);
                bullets.Add(a);

                timer = 0;
            }
            else
            {
                timer += (float)Globals._gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
        void shootBazooka(Vector2 playerPos)
        {
            timeBetweenShots = 1000;
            playerPos = new Vector2(Globals._graphics.PreferredBackBufferWidth / 2, Globals._graphics.PreferredBackBufferHeight / 2 + 15);

            mousePos.X = Mouse.GetState().Position.X - playerPos.X;
            mousePos.Y = Mouse.GetState().Position.Y - playerPos.Y;


            if (timer > timeBetweenShots && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {

                Bullet a = new Bullet(playerPos, mousePos, "big", 10);
                bullets.Add(a);

                timer = 0;
            }
            else
            {
                timer += (float)Globals._gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }



    }
}

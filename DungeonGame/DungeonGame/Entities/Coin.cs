using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.BackendDev;
using DungeonGame.Entities;
using DungeonGame.PlayerManagement;
using DungeonGame.ScreenManagement;
using DungeonGame.ScreenManagement.Screens;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace DungeonGame.Entities
{
    // inherits entity
    class Coin : Entity
    {
        // vars
        Texture2D coinTextureAtlas;
        Rectangle[] coinSourceRect;

        Rectangle coinRect;
        Vector2 coinPos;

        float timer;
        int threshold;
        int currentFrame;

        public bool collected = false;

        

        public Coin()
        {
            coinSourceRect=new Rectangle[8];
            currentFrame=0;
            this.type = "Coin";

        }

        public override void LoadContent(ContentManager Content)
        {
            // gets coin texture
            coinTextureAtlas = Content.Load<Texture2D>("Entities/coinTextureAtlaUPDOWNs");
            
            for(int i = 0; i < coinSourceRect.Length; i++)
            {
                coinSourceRect[i] = new Rectangle(i*32, 0, 32, 32);
            }
            
            coinPos = GetRandomCoinPos();
            coinRect = new Rectangle((int)coinPos.X, (int)coinPos.Y, 32, 32);

            threshold = 80;
            timer = 0;
            currentFrame = 0;
            
            /*
            coinSourceRect[0] = new Rectangle(0,  0, 32, 32);
            coinSourceRect[1] = new Rectangle(32,  0, 32, 32);
            coinSourceRect[2] = new Rectangle(64,  0, 32, 32);
            coinSourceRect[3] = new Rectangle(96,  0, 32, 32);
            coinSourceRect[4] = new Rectangle(128, 0, 32, 32);
            coinSourceRect[5] = new Rectangle(160, 0, 32, 32);
            coinSourceRect[6] = new Rectangle(192, 0, 32, 32);
            coinSourceRect[7] = new Rectangle(224, 0, 32, 32);
            */

        }

        Vector2 GetRandomCoinPos()
        {
            Random rn = new Random();
            TileSearch ts = new TileSearch();
            int x = rn.Next((int)ScreenManager.MapDimentions.X);
            int y = rn.Next((int)ScreenManager.MapDimentions.Y);

            while((ts.WhatObjIDAtThisLocationMAP(x, y) != 'B') && (ts.WhatObjIDAtThisLocationMAP(x, y) != 'E'))
            {
                
                x = rn.Next((int)ScreenManager.MapDimentions.X);
                y = rn.Next((int)ScreenManager.MapDimentions.Y);
            }
            return new Vector2(x * 32, y * 32);
        }

        public override void Update(GameTime gameTime, Player mainPlayer)
        {
            if (collected)
            {
                this.remove = true;
            }
            // Animates the coin
            Animate(gameTime);
            // if the player walks into the coin
            // collected turns true
            if (mainPlayer.playerCollisionBoxRect.Intersects(coinRect)) 
            {// Now i pass in the entire player rather than just its hit box
                //  this means i can access its purse too
                mainPlayer.playerPurse++;
                // i set the rectangle to zero so that the player can collide
                //   into the coin after its disappeard
                coinRect = new Rectangle(0, 0, 0, 0);
                collected = true;
            }
        }

        

        void Animate(GameTime gameTime)
        { // If timer has exceeded threshold then enter 
            //  if statement.
            if(timer > threshold)
            { // if the current frame isnt the last frame
                if(currentFrame != 7)
                { // then increment the frame
                    currentFrame++;
                }else
                { // if it is the last frame then go back 
                     //  to the first frame
                    currentFrame = 0;
                }
                // reset timer
                timer = 0;
            }
            else
            { // if it hasent been longer than the threshold 
                // then keep timing
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            // draws coin
            _spriteBatch.Draw(coinTextureAtlas, coinPos, coinSourceRect[currentFrame], Color.White);

            if (GameScreen.developerView)
            {
                // shows coins hitbox
                _spriteBatch.Draw(DevTexturesManger.Instance.whiteBox1px, coinPos, Color.Aquamarine);
            }
            
        }
    }
}

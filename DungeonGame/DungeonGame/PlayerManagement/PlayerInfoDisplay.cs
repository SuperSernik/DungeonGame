using DungeonGame.BackendDev;
using DungeonGame.ScreenManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.PlayerManagement
{
    public class PlayerInfoDisplay
    {
        //PLAYER STATS
        int HEREplayerHealth;
        Texture2D justRedHearts;
        Texture2D coinTexture;
        Rectangle coinRect;
        Rectangle tagRect;
        Texture2D heartTextureAtlas;
        Rectangle[] hearts;
        SpriteFont EngOldFont18;
        Vector2 textPos;
        string HEREplayerCoins;
        int ammOFHearts;

        // FX
        Texture2D blkPxl;
        Rectangle blkPxlRect;

        public PlayerInfoDisplay() { }

        public void LoadContent(ContentManager Content, Player p)
        {
            heartTextureAtlas = Content.Load<Texture2D>("PlayerTextures/heartTextureAtlasx32");
            justRedHearts = Content.Load<Texture2D>("PlayerTextures/heartTextureAtlasx32JUSTRED");
            coinTexture = Content.Load<Texture2D>("Entities/singleCoinTexture96x32");
            EngOldFont18 = Content.Load<SpriteFont>("Fonts/EngOldFont18");
            blkPxl = Content.Load<Texture2D>("Fx/BlackPixel");

            hearts = new Rectangle[5];
            //Vector2 posOfFirstHeart = new Vector2(1400, 20);

            //tagRect = new Rectangle(1410, 10, 0, 0);
            tagRect = new Rectangle((int)ScreenManager.Instance.Resolution.X - 200 , 10, 0, 0);

            coinRect = new Rectangle((int)tagRect.X + 34*2, (int)tagRect.Y + 36, coinTexture.Width, coinTexture.Height);
            textPos = new Vector2(coinRect.X + 38, coinRect.Y+2);

            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i] = new Rectangle((int)tagRect.X + (i * 34), (int)tagRect.Y, 32, 32);
            }

            HEREplayerCoins = Convert.ToString(p.playerPurse);
            HEREplayerHealth = p.playerHealth;

            blkPxlRect = new Rectangle(coinRect.X, coinRect.Y, coinRect.Width, coinRect.Height);
        }

        

        public void Update(GameTime gameTime, Player p)
        {
            // set the players health to an ingame variable.
            HEREplayerHealth = p.playerHealth;
            // makes sure that the players coins are formatted to
            //  always show 4 digits
            HEREplayerCoins = Convert.ToString($"{p.playerPurse:0000}");

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            // Draws shaded effect under the text so its more visable
            _spriteBatch.Draw(blkPxl, blkPxlRect, new Color(Color.Black, 0.6f));
            // Draws the coin icon
            _spriteBatch.Draw(coinTexture, coinRect, Color.White);
            // Writes the ammount of coins the player has
            _spriteBatch.DrawString(EngOldFont18, HEREplayerCoins, textPos, Color.White);


            // Draws a background for the hearts so that the player knows how many hearts
            //   they are missing.
            for (int i = 0; i < hearts.Length; i++)
            {
                _spriteBatch.Draw(justRedHearts, hearts[i], new Rectangle(0, 0, 32, 32), new Color(Color.LightSeaGreen, 0.6f));
            }
            if (true)
            {

                // MOD divison of the players health as this will show the
                //  number of full hearts the program has to draw
                ammOFHearts = HEREplayerHealth / 2;

                // Then the program draws the ammount of full hearts
                for (int i = 0; i < ammOFHearts; i++)
                {
                    _spriteBatch.Draw(heartTextureAtlas, hearts[i], new Rectangle(0, 0, 32, 32), Color.White);

                }// Finally remainder division leaves a remainder that means the program still has to draw
                 // half a heart
                if ((HEREplayerHealth / (float)2) != 0 && HEREplayerHealth != 10)
                {// then it draws after the last full heart drawn
                    _spriteBatch.Draw(heartTextureAtlas, hearts[ammOFHearts], new Rectangle(32, 0, 32, 32), Color.White);
                }
            }
            else
            {
                for (int i = 0; i < hearts.Length; i++)
                {
                    _spriteBatch.Draw(justRedHearts, hearts[i], new Rectangle(0, 0, 32, 32), Color.Gold);
                }

            }





        }


    }
}

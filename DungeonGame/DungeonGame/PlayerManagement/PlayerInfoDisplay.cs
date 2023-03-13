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
{// this class displays all of the stats of the player such
    // as the health and ammout of coins
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
            // fetches the textures 
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
            // draws all of the items to the screen
            _spriteBatch.Draw(blkPxl, blkPxlRect, new Color(Color.Black, 0.6f));
            _spriteBatch.Draw(coinTexture, coinRect, Color.White);
            _spriteBatch.DrawString(EngOldFont18, HEREplayerCoins, textPos, Color.White);
            for (int i = 0; i < hearts.Length; i++)
            {
                _spriteBatch.Draw(justRedHearts, hearts[i], new Rectangle(0, 0, 32, 32), new Color(Color.LightSeaGreen, 0.6f));
            }
            ammOFHearts = HEREplayerHealth / 2;
            for (int i = 0; i < ammOFHearts; i++)
            {
                _spriteBatch.Draw(heartTextureAtlas, hearts[i], new Rectangle(0, 0, 32, 32), Color.White);
            }      
            if (HEREplayerHealth == 1)
            {
                _spriteBatch.Draw(heartTextureAtlas, hearts[0], new Rectangle(32, 0, 32, 32), Color.White);
            }
            else if (HEREplayerHealth == 3)
            {
                _spriteBatch.Draw(heartTextureAtlas, hearts[1], new Rectangle(32, 0, 32, 32), Color.White);
            }
            else if(HEREplayerHealth == 5)
            {
                _spriteBatch.Draw(heartTextureAtlas, hearts[2], new Rectangle(32, 0, 32, 32), Color.White);
            }
            else if(HEREplayerHealth == 7)
            {
                _spriteBatch.Draw(heartTextureAtlas, hearts[3], new Rectangle(32, 0, 32, 32), Color.White);
            }
            else if (HEREplayerHealth == 9)
            {
                _spriteBatch.Draw(heartTextureAtlas, hearts[4], new Rectangle(32, 0, 32, 32), Color.White);
            }



        }


    }
}

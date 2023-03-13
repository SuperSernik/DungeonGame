using DungeonGame.ScreenManagement;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.ItemManagement.NonItemItems;
using DungeonGame.ScreenManagement.Screens;

namespace DungeonGame.ItemManagement.Items
{
    public class Pistol : Item
    {
        //vars
        Vector2 position;
        Texture2D textureAtlas;

        public float angleOfLine;
        Vector2 distance;

        Vector2 weaponDisplaySize;
        Vector2 weaponSize;

        // SHOOTING

        public Pistol(string newItemType, string newItemName) : base(newItemType, newItemName)
        {

        }

        public override void LoadContent(ContentManager content)
        {// loads texture of the pistol from the weapons atlas
            textureAtlas = content.Load<Texture2D>("Weapons/weaponsAtlas");

            weaponDisplaySize = new Vector2(32, 32);
            weaponSize = new Vector2(32, 32);
            sourceRect = new Rectangle(144, 0, (int)weaponSize.X, (int)weaponSize.Y);
        }


        public override void Update(GameTime gameTime, Vector2 pos)
        {
            position = new Vector2(ScreenManager.Instance.Resolution.X / 2, ScreenManager.Instance.Resolution.Y / 2 + 15); // the 15 is displacement from the center of the screen
            // aims the weapon at the cursor
            MouseState mouse = Mouse.GetState();
            distance.X = mouse.X - position.X;
            distance.Y = mouse.Y - position.Y;
            angleOfLine = (float)Math.Atan2(distance.Y, distance.X);


           

        }

        public override void Draw(SpriteBatch _spriteBatch)
        {// draws the pistol to the screen, also has limitis so that the pistol 
            // doesnt appear upside down once it turns 180 degrees (Pi radians)
            if (angleOfLine <= Math.PI / 2 && angleOfLine >= -Math.PI / 2)
            {
                _spriteBatch.Draw(textureAtlas, new Rectangle((int)position.X, (int)position.Y, (int)weaponDisplaySize.X, (int)weaponDisplaySize.Y), sourceRect, Color.White, angleOfLine, new Vector2(0, weaponSize.Y / 2), SpriteEffects.None, 1);

            }
            else
            {
                _spriteBatch.Draw(textureAtlas, new Rectangle((int)position.X, (int)position.Y, (int)weaponDisplaySize.X, (int)weaponDisplaySize.Y), sourceRect, Color.White, angleOfLine, new Vector2(0, weaponSize.Y / 2), SpriteEffects.FlipVertically, 1);

            }
            //_spriteBatch.Draw(textureAtlas, position, Color.White);




        }

      
    }
}


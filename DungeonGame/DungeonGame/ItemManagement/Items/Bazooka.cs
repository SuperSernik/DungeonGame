﻿using DungeonGame.ScreenManagement;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.ItemManagement.Items
{
    public class Bazooka : Item
    {
        Vector2 position;
        Texture2D textureAtlas;

        public float angleOfLine;
        Vector2 distance;

        Vector2 weaponDisplaySize;
        Vector2 weaponSize;




        public Bazooka(string newItemType, string newItemName) : base(newItemType, newItemName)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            textureAtlas = content.Load<Texture2D>("Weapons/weaponsAtlas");

            weaponDisplaySize = new Vector2(64, 32);
            weaponSize = new Vector2(64, 32);
            sourceRect = new Rectangle(80, 0, (int)weaponSize.X, (int)weaponSize.Y);
        }


        public override void Update(GameTime gameTime, Vector2 pos)
        {
            position = new Vector2(ScreenManager.Instance.Resolution.X / 2, ScreenManager.Instance.Resolution.Y / 2 + 15); // the 15 is displacement from the center of the screen

            MouseState mouse = Mouse.GetState();
            distance.X = mouse.X - position.X;
            distance.Y = mouse.Y - position.Y;
            angleOfLine = (float)Math.Atan2(distance.Y, distance.X);


        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
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

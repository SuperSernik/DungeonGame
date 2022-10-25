using DungeonGame.ScreenManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame_v2.ItemManagement.Items
{
    class Weapon : Item
    {

        Vector2 position;
        Texture2D textureAtlas;
        Rectangle sourceRect;

        float angleOfLine;
        Vector2 distance;

        //Vector2 weaponDisplaySize = new Vector2(96, 32);    // IN GAME
        //Vector2 weaponSize = new Vector2(208, 64);           // ON TILEMAP

        Vector2 weaponDisplaySize = new Vector2(32, 32);    // IN GAME
        Vector2 weaponSize = new Vector2(32, 32);           // ON TILEMAP


        public Weapon(string newItemType, string newItemName, int newItemAmmount) : base(newItemType, newItemName)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            textureAtlas = content.Load<Texture2D>("Weapons/weaponsAtlas");
            sourceRect = new Rectangle(144, 0, (int)weaponSize.X, (int)weaponSize.Y); // penis

        }


        public override void Update(GameTime gameTime, Vector2 pos)
        {
            position = new Vector2(ScreenManager.Instance.Resolution.X / 2, (ScreenManager.Instance.Resolution.Y / 2)  + 15); // the 10 is displacement from the center of the screen

            MouseState mouse = Mouse.GetState();
            distance.X = mouse.X - position.X;
            distance.Y = mouse.Y - position.Y;
            angleOfLine = (float)Math.Atan2(distance.Y, distance.X);


        }
        void shoot()
        {

        }
        public override void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(textureAtlas, new Rectangle((int)position.X, (int)position.Y, (int)weaponDisplaySize.X, (int)weaponDisplaySize.Y), sourceRect, Color.White, angleOfLine, new Vector2(0, weaponSize.Y/2), SpriteEffects.None, 1);
            //_spriteBatch.Draw(textureAtlas, position, Color.White);

        }

    }
}

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
using System.Linq.Expressions;

namespace DungeonGame.ItemManagement.Items
{
    public class Food : Item
    {

        Vector2 position;
        Texture2D textureAtlas;

        public float angleOfLine;
        Vector2 distance;

        Vector2 foodDisplaySize;
        Vector2 foodSize;




        public Food(string newItemType, string newItemName) : base(newItemType, newItemName)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            textureAtlas = content.Load<Texture2D>("Items/foodsAtlas");
            setFoodData(this.itemName, 32, 32);
        }

        public Rectangle SourceRect
        {
            get { return sourceRect; }
        }


        public override void Update(GameTime gameTime, Vector2 pos)
        {
            position = new Vector2(ScreenManager.Instance.Resolution.X / 2, ScreenManager.Instance.Resolution.Y / 2 + 15); // the 10 is displacement from the center of the screen

            MouseState mouse = Mouse.GetState();
            distance.X = mouse.X - position.X;
            distance.Y = mouse.Y - position.Y;
            angleOfLine = (float)Math.Atan2(distance.Y, distance.X);


        }


        public override void Draw(SpriteBatch _spriteBatch)
        {
            // DISPLAY ITEM IN THE MIDDLE
            //_spriteBatch.Draw(textureAtlas, new Rectangle((int)(ScreenManager.Instance.Resolution.X / 2) - 16, (int)(ScreenManager.Instance.Resolution.Y / 2) - 6, 32, 32), SourceRect, Color.White);

            
            if (angleOfLine <= Math.PI / 2 && angleOfLine >= -Math.PI / 2)
            {
                _spriteBatch.Draw(textureAtlas, new Rectangle((int)position.X, (int)position.Y, (int)foodDisplaySize.X, (int)foodDisplaySize.Y), sourceRect, Color.White, angleOfLine, new Vector2(0, foodSize.Y / 2), SpriteEffects.None, 1);

            }
            else
            {
                _spriteBatch.Draw(textureAtlas, new Rectangle((int)position.X, (int)position.Y, (int)foodDisplaySize.X, (int)foodDisplaySize.Y), sourceRect, Color.White, angleOfLine, new Vector2(0, foodSize.Y / 2), SpriteEffects.FlipVertically, 1);

            }
            
            //_spriteBatch.Draw(textureAtlas, position, Color.White);

        }

        void setFoodData(string weapon, int itemWidthInGame, int itemHeightInGame)
        {

            switch (weapon)
            {
                case "cake":
                    foodDisplaySize = new Vector2(itemWidthInGame, itemHeightInGame);            // IN GAME
                    foodSize = new Vector2(64, 64);                   // ON TILEMAP
                    sourceRect = new Rectangle(0, 0, (int)foodSize.X, (int)foodSize.Y); // POS ON TILE MAP
                    break;

                case "vodka":
                    foodDisplaySize = new Vector2(itemWidthInGame, itemHeightInGame);            // IN GAME
                    foodSize = new Vector2(64, 64);                   // ON TILEMAP
                    sourceRect = new Rectangle(64, 0, (int)foodSize.X, (int)foodSize.Y); // POS ON TILE MAP
                    break;

                case "banana":
                    foodDisplaySize = new Vector2(itemWidthInGame, itemHeightInGame);            // IN GAME
                    foodSize = new Vector2(64, 64);                   // ON TILEMAP
                    sourceRect = new Rectangle(128, 0, (int)foodSize.X, (int)foodSize.Y); // POS ON TILE MAP
                    break;





            }


        }
    }
}

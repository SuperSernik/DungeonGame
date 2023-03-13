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

namespace DungeonGame.ItemManagement.Items
{// this class creates the weapon template
    public class Weapon : Item
    {
        // vars
        Vector2 position;
        Texture2D textureAtlas;

        public float angleOfLine;
        Vector2 distance;

        Vector2 weaponDisplaySize;
        Vector2 weaponSize;

        public Weapon(string newItemType, string newItemName) : base(newItemType, newItemName)
        {
            
        }

        public override void LoadContent(ContentManager content)
        {// loads texture from atlas
            textureAtlas = content.Load<Texture2D>("Weapons/weaponsAtlas");
            setWeaponData(this.itemName, 32, 32);
        }

        public Rectangle SourceRect
        {
            // get the location for the texture off of the atlas
            get { return sourceRect; }
        }


        public override void Update(GameTime gameTime, Vector2 pos)
        {// the 15 is displacement from the center of the screen
            position = new Vector2(ScreenManager.Instance.Resolution.X / 2, ScreenManager.Instance.Resolution.Y / 2 + 15); 
            // makes sure the weapons points in the correct direction when the player holds
            // it in their hand
            MouseState mouse = Mouse.GetState();
            distance.X = mouse.X - position.X;
            distance.Y = mouse.Y - position.Y;
            angleOfLine = (float)Math.Atan2(distance.Y, distance.X);


        }
        void shoot()
        {

        }
        public override void Draw(SpriteBatch _spriteBatch)
        {// draws the weapon to the screen
            if(angleOfLine <= Math.PI/2 && angleOfLine >= -Math.PI / 2)
            {
                _spriteBatch.Draw(textureAtlas, new Rectangle((int)position.X, (int)position.Y, (int)weaponDisplaySize.X, (int)weaponDisplaySize.Y), sourceRect, Color.White, angleOfLine, new Vector2(0, weaponSize.Y / 2), SpriteEffects.None, 1);

            }
            else
            {
                _spriteBatch.Draw(textureAtlas, new Rectangle((int)position.X, (int)position.Y, (int)weaponDisplaySize.X, (int)weaponDisplaySize.Y), sourceRect, Color.White, angleOfLine, new Vector2(0, weaponSize.Y / 2), SpriteEffects.FlipVertically, 1);

            }
            //_spriteBatch.Draw(textureAtlas, position, Color.White);

        }

        void setWeaponData(string weapon,int itemWidthInGame, int itemHeightInGame)
        {
            switch (weapon)
            {// fetches the coords of the texture on the atlas
                case "pp":
                    weaponDisplaySize = new Vector2(32, 32);            // IN GAME
                    weaponSize = new Vector2(32, 32);                   // ON TILEMAP
                    sourceRect = new Rectangle(0, 0, (int)weaponSize.X, (int)weaponSize.Y); // POS ON TILE MAP
                    break;

                case "pistol":
                    weaponDisplaySize = new Vector2(32, 32);
                    weaponSize = new Vector2(32, 32);
                    sourceRect = new Rectangle(144, 0, (int)weaponSize.X, (int)weaponSize.Y);
                    break;

                case "nyanLauncher":
                    weaponDisplaySize = new Vector2(48, 32);
                    weaponSize = new Vector2(48, 32);
                    sourceRect = new Rectangle(32, 0, (int)weaponSize.X, (int)weaponSize.Y);
                    break;

                case "bazooka":
                    weaponDisplaySize = new Vector2(64, 32);
                    weaponSize = new Vector2(64, 32);
                    sourceRect = new Rectangle(80, 0, (int)weaponSize.X, (int)weaponSize.Y);
                    break;

                default:
                    weaponDisplaySize = new Vector2(32, 32);
                    weaponSize = new Vector2(32, 32);
                    sourceRect = new Rectangle(288, 288, (int)weaponSize.X, (int)weaponSize.Y);
                    break;

            }


        }
    }
}

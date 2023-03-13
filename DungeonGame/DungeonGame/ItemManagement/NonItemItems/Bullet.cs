using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace DungeonGame.ItemManagement.NonItemItems
{
    public class Bullet
    {
        // vars
        Texture2D texture;
        Rectangle rect;
        Vector2 pos;
        float velocity, prevVelocity;
        Vector2 direction;
        int bulletDims;
        float rotation;


        public Bullet(Vector2 spawnLoc, Vector2 mDirection, string bulletSize, float nVelocity)
        {// sets all of the values that identify the bullet
            pos = spawnLoc;
            direction = mDirection;
            rotation = 0;
            velocity = nVelocity;
            prevVelocity = nVelocity;

            // sets the diameter of the bullet depending on the side
            if(bulletSize == "small")
            {
                bulletDims = 8;
            }
            if (bulletSize == "med")
            {
                bulletDims = 16;
            }
            if (bulletSize == "big")
            {
                bulletDims = 32;
            }

            rect = new Rectangle((int)pos.X, (int)pos.Y, bulletDims, bulletDims);

            texture = Globals._content.Load<Texture2D>("Bullets/whiteBullet");
            
        }


        public void Update()
        {
            /*
            pos.X = pos.X + (int)(0.1 * direction.X);
            pos.Y = pos.Y + (int)(0.1 * direction.Y);
            */
            // creates the direction vector of the bullet
            double dirMOD = Math.Sqrt(((direction.X * direction.X) + (direction.Y * direction.Y)));
            Vector2 newV = direction / (int)dirMOD;
            pos += (newV) * velocity;

            rect.X = (int)pos.X;
            rect.Y = (int)pos.Y;

            /* EPIC SLOW MO EFFECT
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                velocity = 2;
            }
            else
            {
                velocity = prevVelocity;
            }
            */

        }

        public void Draw()
        {
            //Globals._spriteBatch.Draw(texture, rect, Color.White);
            // draws the bullet
            Globals._spriteBatch.Draw(texture, rect, new Rectangle(0, 0, 16, 16), Color.White, rotation, new Vector2(8, 8), SpriteEffects.None, 1);
        }



    }
}

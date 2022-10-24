using DungeonGame.PlayerManagement;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.ScreenManagement.Screens;

namespace DungeonGame.BackendDev
{
    class Line
    {
        bool visable = true;

        Texture2D line;
        float angleOfLine;
        Vector2 distance;
        Vector2 linePos;
        float rotation;
        double lineLength;

        Vector2 from, to;

        public Line()
        {
            from = Vector2.Zero;
            to = Vector2.Zero;
            if (!GameScreen.developerView)
            {
                visable = false;
            }
        }
        public Line(Vector2 newFrom, Vector2 newTo)
        {
            if(newFrom != Vector2.Zero)
            {
                from = newFrom;

            }
            if (newFrom != Vector2.Zero)
            {
                to = newTo;

            }
            if (!GameScreen.developerView)
            {
                visable = false;
            }
        }
        public Line(Vector2 newFrom, Vector2 newTo, bool newVISABLE)
        {
            if (newFrom != Vector2.Zero)
            {
                from = newFrom;

            }
            if (newFrom != Vector2.Zero)
            {
                to = newTo;

            }
            visable = newVISABLE;
        }



        public void LoadContent(ContentManager content)
        {
            //line = new Texture2D(gdm.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            //line.SetData(new[] { Color.White });



            line = content.Load<Texture2D>("Fx/BlackPixel");
            angleOfLine = (float)(2 * Math.PI);

            linePos = new Vector2(1600 / 2, 960 / 2);

        }

        public void Update(GameTime gameTime, Player p) // PLAYER TO MOUSE
        {
            MouseState mouse = Mouse.GetState();
            distance.X = mouse.X - linePos.X;
            distance.Y = mouse.Y - linePos.Y;
            rotation = (float)Math.Atan2(distance.Y, distance.X);
            angleOfLine = rotation;

            linePos.X = (int)from.X;
            linePos.Y = (int)from.Y;



            lineLength = Math.Sqrt((distance.X * distance.X) + (distance.Y * distance.Y));

        }
        public void Update(GameTime gameTime, Vector2 Ufrom, Vector2 Uto) // DYNAMIC FROM TO
        {
            from = Ufrom;
            to = Uto;

            distance.X = to.X - linePos.X;
            distance.Y = to.Y - linePos.Y;
            rotation = (float)Math.Atan2(distance.Y, distance.X);
            angleOfLine = rotation;

            linePos.X = (int)from.X;
            linePos.Y = (int)from.Y;

            lineLength = Math.Sqrt((distance.X * distance.X) + (distance.Y * distance.Y));

        }
        public void Update(GameTime gameTime) // STATIC FROM TO 
        {
            distance.X = to.X - linePos.X;
            distance.Y = to.Y - linePos.Y;
            rotation = (float)Math.Atan2(distance.Y, distance.X);
            angleOfLine = rotation;

            linePos.X = (int)from.X;
            linePos.Y = (int)from.Y;

            lineLength = Math.Sqrt((distance.X * distance.X) + (distance.Y * distance.Y));

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (visable)
            {
                _spriteBatch.Draw(line, new Rectangle((int)linePos.X, (int)linePos.Y, (int)lineLength, 1), null, Color.White, angleOfLine, new Vector2(0, 0), SpriteEffects.None, 0);

            }


        }
    }
}

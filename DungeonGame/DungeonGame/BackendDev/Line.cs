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

namespace DungeonGame.BackendDev
{
    class Line
    {

        Texture2D line;
        float angleOfLine;
        Vector2 distance;
        Vector2 linePos;
        float rotation;
        int lineLength;

        public Line(int newLength)
        {
            lineLength = newLength;
        }

        public void LoadContent(ContentManager content)
        {
            //line = new Texture2D(gdm.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            //line.SetData(new[] { Color.White });

            line = content.Load<Texture2D>("Fx/BlackPixel");
            angleOfLine = (float)(2 * Math.PI);

            linePos = new Vector2(1600 / 2, 960 / 2);

        }

        public void Update(GameTime gameTime, Player p)
        {
            //angleOfLine = (float)(gameTime.ElapsedGameTime.TotalSeconds * 2);

            MouseState mouse = Mouse.GetState();
            distance.X = mouse.X - linePos.X;
            distance.Y = mouse.Y - linePos.Y;
            rotation = (float)Math.Atan2(distance.Y, distance.X);

            /*
            distance.X = p.playerPos.X - linePos.X;
            distance.Y = p.playerPos.Y - linePos.Y;
            rotation = (float)Math.Atan2(distance.Y, distance.X);
            */
            angleOfLine = rotation;
            linePos.X = (int)p.playerPosition.X + 16;
            linePos.Y = (int)p.playerPosition.Y + 24;



        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Draw(line, new Rectangle((int)linePos.X, (int)linePos.Y, lineLength, 1), null, Color.White, angleOfLine, new Vector2(0, 0), SpriteEffects.None, 0);

        }
    }
}

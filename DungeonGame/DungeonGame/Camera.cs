﻿using DungeonGame.PlayerManagement;
using DungeonGame.ScreenManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonGame
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public static double angle = 0;
        public Matrix RotateM, ZoomM;

        //SHAKE
        static int threshold = 40;
        static float timer = 0, jitter = 0.02f;

        //ZOOM
        static float zoom = 1f;

        public void Shake(GameTime gt, bool shake)
        {
            if (shake)
            {
                if (timer > threshold)
                {
                    if (angle != jitter)
                    {
                        angle = jitter;
                    }
                    else if (angle != -jitter)
                    {
                        angle = -jitter;
                    }
                    timer = 0;
                }
                else
                {
                    timer += (float)gt.ElapsedGameTime.TotalMilliseconds;
                }
            }
            else
            {
                angle = 0;
            }



            RotateM = new Matrix(new Vector4((float)Math.Cos(angle), (float)-Math.Sin(angle), 0, 0),
                                          new Vector4((float)Math.Sin(angle), (float)Math.Cos(angle), 0, 0),
                                          new Vector4(0, 0, 1, 0),
                                          new Vector4(0, 0, 0, 1));
        }

        public void Zoom(GameTime gt)
        {

            if (Keyboard.GetState().IsKeyDown(Globals.zoomIn))
            {
                zoom += 0.1f;
            }
            if (Keyboard.GetState().IsKeyDown(Globals.zoomOut) && zoom > 0.2)
            {
                zoom -= 0.1f;
            }


            ZoomM = new Matrix(new Vector4(zoom, 0, 0, 0),
                               new Vector4(0, zoom, 0, 0),
                               new Vector4(0, 0, zoom, 0),
                               new Vector4(0, 0, 0, 1));

        }

        public void Follow(Player target, GameTime gt)
        {
            var position = Matrix.CreateTranslation(
              -target.playerPosition.X - (target.playerRect.Width / 2),
              -target.playerPosition.Y - (target.playerRect.Height / 2),
              0);

            var offset = Matrix.CreateTranslation(
                ScreenManager.Instance.Resolution.X / 2,
                ScreenManager.Instance.Resolution.Y / 2,
                0);

            var mid = Matrix.CreateTranslation(
                ScreenManager.Instance.Resolution.X - ScreenManager.Instance.Resolution.X,
                ScreenManager.Instance.Resolution.Y - ScreenManager.Instance.Resolution.Y,
                0);

            Shake(gt, false);
            Zoom(gt);

            if (ScreenManager.MapDimentions == new Vector2(100, 100))
            {
                Transform = position  * ZoomM * RotateM * offset;
            }
            if (ScreenManager.MapDimentions == new Vector2(50, 30))
            {
                Transform = mid;

            }
        }
    }
}

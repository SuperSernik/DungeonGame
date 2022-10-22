using DungeonGame.PlayerManagement;
using DungeonGame.ScreenManagement;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Player target)
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

            if(ScreenManager.MapDimentions == new Vector2(100, 100))
            {
                Transform = position * offset;

            }
            if (ScreenManager.MapDimentions == new Vector2(50, 30))
            {
                Transform = mid;

            }
        }
    }
}

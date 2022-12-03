using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public class Globals
    {
        public static SpriteBatch _spriteBatch { get; set; }
        public static GraphicsDeviceManager _graphics { get; set; }
        public static ContentManager _content { get; set; }
        public static GameTime _gameTime { get; set; }


        public static Keys upKey = Keys.W;
        public static Keys downKey = Keys.S;
        public static Keys leftKey = Keys.A;
        public static Keys rightKey = Keys.D;
        public static Keys sprintKey = Keys.LeftShift;

        public static Keys fullScreenKey = Keys.F11;
        public static Keys developerModeKey = Keys.F8;
        public static Keys zoomIn = Keys.Add;
        public static Keys zoomOut = Keys.Subtract;

        public static Keys useKey = Keys.F;
        public static Keys inventoryKey = Keys.E;
        public static Keys dropItemKey = Keys.Q;

        public static Vector2 tileSize = new Vector2(32, 32);

    }
}

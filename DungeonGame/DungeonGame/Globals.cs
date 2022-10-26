using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Globals
    {
        public static Keys upKey = Keys.W;
        public static Keys downKey = Keys.S;
        public static Keys leftKey = Keys.A;
        public static Keys rightKey = Keys.D;
        public static Keys sprintKey = Keys.LeftShift;

        public static Keys fullScreenKey = Keys.F11;
        public static Keys developerModeKey = Keys.F8;

        public static Keys useKey = Keys.F;
        public static Keys inventoryKey = Keys.E;
        public static Keys dropItemKey = Keys.Q;

        public static Vector2 tileSize = new Vector2(32, 32);

    }
}

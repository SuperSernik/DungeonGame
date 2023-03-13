using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.BackendDev
{
    public class Logic
    {

        // vars
        bool value = false;
        bool beingPressed = false;
        bool output;

        public Logic(bool originalValue)
        {
            output = originalValue;
        }

        // acts as a reusable logic gate
        public bool ToggleByKey(Keys key)
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.F8) && beingPressed == false)
            {
                beingPressed = true;
                if (value == false)
                {
                    output = true;
                }
                else if (value == true)
                {
                    output = false;

                }
            }

            if (Keyboard.GetState().IsKeyUp(Keys.F8))
            {
                beingPressed = false;
            }

            return output;
        }



    }
}

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

        public bool Toggle(bool toggle, bool clk)
        {
            if (toggle && clk)
            {
                return true;
            }
            else if (toggle && !clk)
            {
                return false;
            }

            return false;

        }



    }
}

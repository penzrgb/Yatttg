using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    static class PlayerFactory
    {
        internal static Player CreatePlayer(YatttgModel ym, string name, char marker)
        {
            // Get the marker that the player has requested
            if (ym.Nort.Character.Equals(marker))
            {
                return new Player(name, ym.Nort);
            }
            else if (ym.Cross.Character.Equals(marker))
            {
                return new Player(name, ym.Cross);
            }
            
            // No appropriate marker was found.
            throw new ArgumentException("The marker selected is not available.");            
        }
    }
}

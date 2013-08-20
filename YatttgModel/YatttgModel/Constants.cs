using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    static class Constants
    {
        public enum GameState : int
        {
            PlayerInfo = 0,
            InProgress = 1,
            Win = 2,
            Tie = 3
        }

        internal const char NortDefault = 'O';
        internal const char CrossDefault = 'X';
    }
}

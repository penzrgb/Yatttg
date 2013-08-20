using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    interface IYatttgFacade
    {
        Nort Nort { get; set; }
        Cross Cross { get; set; }
        Player CreatePlayer(string name, char marker);
        void InitGame(Player p1, Player p2);
        Constants.GameState MakeMove(Player player, int position);
        Player StartNextTurn();
    }
}

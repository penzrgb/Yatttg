using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    public interface IYatttgFacade
    {
        Nort Nort { get; set; }
        Cross Cross { get; set; }
        Cell[,] GetGrid();
        Constant.GameState InitGame(Player p1, Player p2);
        Constant.GameState MakeMove(Player player, int position);
        Player StartNextTurn();
    }
}

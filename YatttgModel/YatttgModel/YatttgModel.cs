using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    public class YatttgModel : IYatttgFacade
    {
        Player p1_, p2_;
        bool p1Turn;

        CellManager cm_;
        Constant.GameState currentGameState_;

        public Nort Nort { get; set; }
        public Cross Cross { get; set; }

        public YatttgModel()
        {
            // Initialize default values.
            p1_ = null;
            p2_ = null;

            // Give Nort and Cross default values.
            Nort = new Nort();
            Cross = new Cross();

            cm_ = new CellManager();

            // Initial state is to get player information.
            currentGameState_ = Constant.GameState.PlayerInfo;
        }

        Cell[,] IYatttgFacade.GetGrid()
        {
            return cm_.Grid;
        }

        Constant.GameState IYatttgFacade.InitGame(Player p1, Player p2)
        {
            p1_ = p1;
            p2_ = p2;

            // Flip a coin on who should start first.
            p1Turn = RandomFirstTurn();

            // Init grid
            cm_.InitGrid();

            // Game is now running.
            currentGameState_ = Constant.GameState.InProgress;
            return currentGameState_;
        }

        Constant.GameState IYatttgFacade.MakeMove(Player player, int position)
        {
            // To match up with internal array range.
            position--;

            // Update the grid
            cm_.SetCellAtIndex(position, player.Marker);

            currentGameState_ = GameLogic.CheckGridForWinner(cm_, player.Marker, 
                currentGameState_);

            return currentGameState_;
        }

        Player IYatttgFacade.StartNextTurn()
        {
            // Determine who gets to play next.
            p1Turn = !p1Turn;

            if (p1Turn)
                return p1_;
            else
                return p2_;
        }

        private bool RandomFirstTurn()
        {
            // The maxValue argument is exclusive; not inclusive.
            int r = new Random().Next(0, 2);
            if (r == 0)
                return false;
            else
                return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    internal static class GameLogic
    {
        internal static Constant.GameState CheckGridForWinner(CellManager cm, IMarker m,
            Constant.GameState currentGameState)
        {
            Constant.GameState result = currentGameState;

            // Check winning conditions for the newly created move
            if (cm.AllocCount == Constant.MaxOptions)
                result = Constant.GameState.Tie;
            else
            {
                // We only need to check the grid for the marker that has
                // just been placed down.
                result = CheckRows(cm, m, currentGameState);
                result = CheckColumns(cm, m, currentGameState);
                result = CheckDiagonals(cm, m, currentGameState);
            }

            return result;
        }

        private static Constant.GameState CheckRows(CellManager cm, IMarker m,
            Constant.GameState currentGameState)
        {
            Constant.GameState result = currentGameState;

            if (result == Constant.GameState.Win)
                return result;

            for (int row = 0; row < Constant.GridSize; row++)
            {
                int cnt = 0;
                for (int column = 0; column < Constant.GridSize; column++)
                {
                    if (cm.Grid[row, column].Marker.Equals(m))
                        cnt++;
                }

                if (cnt == Constant.GridSize)
                    return Constant.GameState.Win;
            }

            return result;
        }

        private static Constant.GameState CheckColumns(CellManager cm, IMarker m,
            Constant.GameState currentGameState)
        {
            Constant.GameState result = currentGameState;

            if (result == Constant.GameState.Win)
                return result;

            for (int column = 0; column < Constant.GridSize; column++)
            {
                int cnt = 0;
                for (int row = 0; row < Constant.GridSize; row++)
                {
                    if (cm.Grid[row, column].Marker.Equals(m))
                        cnt++;
                }

                if (cnt == Constant.GridSize)
                    return Constant.GameState.Win;
            }

            return result;
        }

        private static Constant.GameState CheckDiagonals(CellManager cm, IMarker m,
            Constant.GameState currentGameState)
        {
            Constant.GameState result = currentGameState;

            if (result == Constant.GameState.Win)
                return result;

            int cnt = 0;

            // Check leading diagonal.
            for (int i = 0; i < Constant.GridSize; i++)
            {
                if (cm.Grid[i, i].Marker.Equals(m))
                    cnt++;
            }

            if (cnt == Constant.GridSize)
                return Constant.GameState.Win;
            else
            {
                // Reset the counter, check antidiagonal.
                cnt = 0;
                for (int i = 2; i >= 0; i--)
                {
                    if (cm.Grid[i, i].Marker.Equals(m))
                        cnt++;
                }

                if (cnt == Constant.GridSize)
                    return Constant.GameState.Win;
            }

            // No result was found on the diagonals.
            return result;
        }
    }
}

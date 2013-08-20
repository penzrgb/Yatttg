using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    internal class CellManager
    {
        public Cell[,] Grid { get; private set; }
        public int AllocCount { get; private set; }

        public CellManager()
        {
            InitGrid();
        }

        internal void InitGrid()
        {
            // 3x3 matrix
            Grid = new Cell[Constant.GridSize, Constant.GridSize];

            for (int i = 0; i < Constant.GridSize; i++)
                for (int j = 0; j < Constant.GridSize; j++)
                    Grid[i, j] = new Cell();

            AllocCount = 0;
        }

        internal void SetCellAtIndex(int index, IMarker marker)
        {
            if (GetCellAtIndex(index).Marker != null)
                throw new ArgumentException("This cell is occupied!");
            else
            {
                int row = index / Constant.GridSize;
                int column = index % Constant.GridSize;

                Grid[row, column] = new Cell(marker);
                AllocCount++;
            }
        }

        private Cell GetCellAtIndex(int index)
        {
            int row = index / Constant.GridSize;
            int column = index % Constant.GridSize;
            return Grid[row, column];
        }
    }
}

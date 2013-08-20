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
            Grid = new Cell[3, 3];
            AllocCount = 0;
        }

        internal void SetCellAtIndex(int index, IMarker marker)
        {
            if (GetCellAtIndex(index) != null)
                throw new ArgumentException("This cell is occupied!");
            else
            {
                int row = index / 3;
                int column = index % 3;

                Grid[row, column] = new Cell(marker);
                AllocCount++;
            }
        }

        private Cell GetCellAtIndex(int index)
        {
            int row = index / 3;
            int column = index % 3;
            return Grid[row, column];
        }
    }
}

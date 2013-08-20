using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    internal class Cell
    {
        public IMarker Marker { get; set; }

        public Cell()
        {
            // Set the cell to not have a marker by default.
            this.Marker = null;
        }

        public Cell(IMarker marker)
        {
            this.Marker = marker;
        }
    }
}

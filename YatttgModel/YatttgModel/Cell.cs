using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    class Cell
    {
        public IMarker Marker { get; set; }

        public Cell()
        {
            // Set the cell to not have a marker by default.
            this.Marker = null;
        }
    }
}

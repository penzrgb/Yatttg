using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    class Player
    {
        public string Name { get; set; }
        public IMarker Marker { get; set; }

        public Player(string name, IMarker marker)
        {
            this.Name = name;
            this.Marker = marker;
        }
    }
}

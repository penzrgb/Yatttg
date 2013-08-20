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
        public Marker Marker { get; set; }

        public Player(string name, Marker marker)
        {
            this.Name = name;
            this.Marker = marker;
        }
    }
}

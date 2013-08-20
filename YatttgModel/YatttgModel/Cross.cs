using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    public class Cross : IMarker
    {
        public char Character
        {
            get;
            set;
        }

        public Cross()
        {
            // Default value for Cross's character.
            this.Character = Constant.CrossDefault;
        }
    }
}

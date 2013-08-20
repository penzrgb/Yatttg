using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    public class Nort : IMarker
    {
        public char Character
        {
            get;
            set;
        }

        public Nort()
        {
            // Default value for Nort's character.
            this.Character = Constant.NortDefault;
        }
    }
}

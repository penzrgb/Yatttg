﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatttgModel
{
    abstract class AbstractMarker : IMarker
    {
        public char Character
        {
            get;
            set;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class FallingBlockZ:FallingBlock
    {
        public FallingBlockZ()
        {
            List.Add(new Block(0, 0));
            List.Add(new Block(-1, 0));
            List.Add(new Block(0, -1));
            List.Add(new Block(1, 0 - 1));
        }
    }
}
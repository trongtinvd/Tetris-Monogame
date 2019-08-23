using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class FieldTexture : MyTexture
    {
        public Rectangle Source { get; private set; }

        public FieldTexture()
        {
            Source = new Rectangle(142, 81, 521 - 142, 542 - 81);
        }
    }
}

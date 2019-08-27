using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class BlockTexture : MyTexture
    {

        public BlockTexture()
        {

        }

        public Rectangle Source(Block block)
        {
            Rectangle result = new Rectangle((int)block.Color * 8, 0, 8, 8);
            return result;
        }
    }
}

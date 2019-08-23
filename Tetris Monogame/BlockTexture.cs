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
            BlockColor color = block.Color;

            if (color == BlockColor.Random)
            {
                Random r = new Random();
                int numberOfColor = Enum.GetNames(typeof(BlockColor)).Length - 1;
                color = (BlockColor)r.Next(0, numberOfColor);
            }

            Rectangle result = new Rectangle();

            result.X = (int)color * 8;
            result.Y = 0;
            result.Width = 8;
            result.Height = 8;

            return result;
        }
    }
}

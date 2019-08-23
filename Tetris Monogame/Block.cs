using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class Block
    {
        public Point Location { get; set; }
        public BlockColor Color { get; set; }

        public Block()
        {
            Location = new Point();
            Color = BlockColor.Black;
        }

        public Block(Point location)
        {
            Location = location;
            Color = BlockColor.Black;
        }
        public Block(Point location, BlockColor color)
        {
            Location = location;
            Color = color;
        }
    }
}

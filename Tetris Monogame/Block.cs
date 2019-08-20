using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class Block
    {
        //public int Row { get; set; }
        //public int Column { get; set; }
        public Point Location { get; set; }
        public BlockColor Color { get; set; }

        public Block()
        {
            Location = new Point();
            Color = BlockColor.White;
        }

        public Block(int row, int column)
        {
            Location = new Point(row, column);
            Color = BlockColor.White;
        }
    }
}

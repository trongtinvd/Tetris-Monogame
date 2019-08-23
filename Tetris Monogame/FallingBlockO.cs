using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class FallingBlockO : FallingBlock
    {
        public FallingBlockO(Point origin, BlockColor color) : base(origin, color)
        {

        }

        protected override void MakeDefaultShapes()
        {
            shapes = new int[1, 2, 2]
            {
                {
                    {1,1},
                    {1,1}
                }
            };
        }
    }
}

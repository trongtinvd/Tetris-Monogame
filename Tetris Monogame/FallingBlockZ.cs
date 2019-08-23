using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class FallingBlockZ : FallingBlockWithShape
    {
        public FallingBlockZ(Point origin, BlockColor color) : base(origin, color)
        {

        }

        protected override void MakeDefaultShapes()
        {
            shapes = new int[2, 3, 3]
            {
                {
                    {0,0,0},
                    {1,1,0},
                    {0,1,1}
                },
                {
                    {0,1,0},
                    {1,1,0},
                    {1,0,0}
                }
            };
        }
    }
}

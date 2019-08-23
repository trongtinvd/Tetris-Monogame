using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    static class FallingBlockGenerator
    {
        public static FallingBlockWithShape Generate(BlocksShape shape, Point origin)
        {
            FallingBlockWithShape result;

            if (shape == BlocksShape.Random)
            {
                var availbleShapes = Enum.GetValues(typeof(BlocksShape)).Length - 1;
                int randomNumber = new Random().Next(0, availbleShapes);
                shape = (BlocksShape)randomNumber;
            }

            switch (shape)
            {
                case BlocksShape.I:
                    result = new FallingBlockI(origin, BlockColor.Red);
                    break;
                case BlocksShape.J:
                    result = new FallingBlockJ(origin, BlockColor.Blue);
                    break;
                case BlocksShape.L:
                    result = new FallingBlockL(origin, BlockColor.Orange);
                    break;
                case BlocksShape.O:
                    result = new FallingBlockO(origin, BlockColor.Yellow);
                    break;
                case BlocksShape.S:
                    result = new FallingBlockS(origin, BlockColor.Violet);
                    break;
                case BlocksShape.T:
                    result = new FallingBlockT(origin, BlockColor.Azure);
                    break;
                case BlocksShape.Z:
                    result = new FallingBlockZ(origin, BlockColor.Green);
                    break;
                default:
                    throw new Exception("unknown block shape");
            }

            return result;
        }
    }
}

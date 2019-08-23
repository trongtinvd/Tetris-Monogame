using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class FallingBlock : BlockCollection
    {
        public Point Origin { get; set; }

        public FallingBlock()
        {
            Origin = new Point();
        }

        public void MoveLeft()
        {
            foreach (Block block in List)
            {
                block.Location.X--;
            }
            Origin.X--;
        }

        public void MoveRight()
        {
            foreach (Block block in List)
            {
                block.Location.X++;
            }
            Origin.X++;
        }

        public void MoveDown(double speed)
        {
            foreach (Block block in List)
            {
                block.Location.Y += speed;
            }
            Origin.Y += speed;
        }

        private void Swap(ref double x, ref double y)
        {
            double t = x;
            x = y;
            y = t;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class FallingBlock : BlockCollection
    {
        protected Point CenterPoint;

        public FallingBlock()
        {

        }

        public FallingBlock(BlocksShape shape)
        {
            CenterPoint.X = 4;
            CenterPoint.Y = 10;


            if (shape == BlocksShape.I)
            {
                List = new FallingBlockI().List;
            }
            else if (shape == BlocksShape.L)
            {
                List = new FallingBlockL().List;
            }
            else if (shape == BlocksShape.O)
            {
                List = new FallingBlockO().List;
            }
            else if (shape == BlocksShape.J)
            {
                List = new FallingBlockJ().List;
            }
            else if (shape == BlocksShape.S)
            {
                List = new FallingBlockS().List;
            }
            else if (shape == BlocksShape.T)
            {
                List = new FallingBlockT().List;
            }
            else if (shape == BlocksShape.Z)
            {
                List = new FallingBlockZ().List;
            }
            else if (shape == BlocksShape.Random)
            {
                var availbleShapes = Enum.GetValues(typeof(BlocksShape));
                int randomNumber = new Random().Next(0, availbleShapes.Length);
                BlocksShape randomShape = (BlocksShape)availbleShapes.GetValue(randomNumber);
                this.List = new FallingBlock(randomShape).List;
            }

            foreach (Block block in List)
            {
                block.Location += CenterPoint;
            }
        }
        

        public void MoveLeft()
        {
            foreach (Block block in List)
            {
                block.Location.X--;
            }
            CenterPoint.X--;
        }

        public void MoveRight()
        {
            foreach (Block block in List)
            {
                block.Location.X++;
            }
            CenterPoint.X++;
        }


        //temporary
        private double move = 0;
        public void MoveDown(double speed)
        {
            move += speed;
            while(move>1)
            {
                foreach (Block block in List)
                {
                    block.Location.Y++;
                }
                CenterPoint.Y++;
                move--;
            }
        }

        public void Rotate90DegreeClockwire()
        {
            foreach (Block block in List)
            {
                int column = block.Location.X - (int)CenterPoint.X;
                int row = block.Location.Y - (int)CenterPoint.Y;

                Swap(ref column, ref row);
                block.Location.X = -column + (int)CenterPoint.X;
                block.Location.Y = row + (int)CenterPoint.Y;
            }
        }

        private void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }
    }
}

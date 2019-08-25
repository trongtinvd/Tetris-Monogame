using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class FallingBlock : BlockCollection
    {
        protected int[,,] shapes;
        protected int _currentShape;

        public BlockColor Color { get; set; }
        public Point Origin { get; set; }

        public int CurrentShape
        {
            get
            {
                return _currentShape;
            }
            set
            {
                _currentShape = value % shapes.GetLength(0);
            }
        }


        public FallingBlock()
        {
            Origin = new Point();
            Color = BlockColor.Black;
        }

        public FallingBlock(Point origin, BlockColor color)
        {
            _currentShape = 0;
            MakeDefaultShapes();
            Origin = origin;
            Color = color;
            ImplementShape();
        }

        protected virtual void ImplementShape()
        {
            for (int x = 0; x < shapes.GetLength(1); x++)
                for (int y = 0; y < shapes.GetLength(2); y++)
                    if (shapes[CurrentShape, x, y] == 1)
                    {
                        List.Add(new Block(Origin + new Point(x, y), Color));
                    }
        }

        public virtual void Transform()
        {
            List.Clear();
            CurrentShape++;
            ImplementShape();
        }

        public void MoveLeft(int offset)
        {
            foreach (Block block in List)
            {
                block.Location.X -= offset;
            }
            Origin.X -= offset;
        }

        public void MoveRight(int offset)
        {
            foreach (Block block in List)
            {
                block.Location.X += offset;
            }
            Origin.X += offset;
        }

        public void MoveDown(double speed)
        {
            foreach (Block block in List)
            {
                block.Location.Y += speed;
            }
            Origin.Y += speed;
        }

        internal void MoveBack()
        {
            foreach(Block block in List)
            {
                block.Location.Y -= 1;
            }
            Origin.Y -= 1;
        }

        internal bool BelowBottom(int bottom)
        {
            foreach (Block block in List)
            {
                if ((int)block.Location.Y > bottom)
                    return true;
            }
            return false;
        }

        public void AdjustHorizontalPosition(int minPosition, int maxPosition)
        {
            if (RightMostBlock.Location.X >= maxPosition)
            {
                int offset = maxPosition - (int)RightMostBlock.Location.X;
                MoveLeft(offset + 1);
            }
            else if (LeftMostBlock.Location.X < 0)
            {
                int offset = minPosition - (int)LeftMostBlock.Location.X;
                MoveRight(offset);
            }
        }

        public bool LeftSideIsFree(MergeBlocks mergeBlocks)
        {
            foreach (Block block1 in this.List)
            {
                foreach (Block block2 in mergeBlocks.List)
                {
                    if ((int)block2.Location.X == (int)block1.Location.X - 1 && (int)block2.Location.Y == (int)block1.Location.Y)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool RightSideIsFree(MergeBlocks mergeBlocks)
        {
            foreach (Block block1 in this.List)
            {
                foreach (Block block2 in mergeBlocks.List)
                {
                    if ((int)block2.Location.X == (int)block1.Location.X + 1 && (int)block2.Location.Y == (int)block1.Location.Y)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

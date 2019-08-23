using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class FallingBlockWithShape : FallingBlock
    {
        protected int[,,] shapes;
        protected int _currentShape;

        public BlockColor Color { get; set; }
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
        

        public FallingBlockWithShape(Point origin, BlockColor color)
        {
            shapes = new int[1, 1, 1];
            CurrentShape = 0;
            MakeDefaultShapes();
            Origin = origin;
            Color = color;
            ImplementShape();
        }

        protected virtual void MakeDefaultShapes()
        {

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
    }
}

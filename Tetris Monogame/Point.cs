using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class Point
    {
        public decimal X;
        public decimal Y;

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

    }
}

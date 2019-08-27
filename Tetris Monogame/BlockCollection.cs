using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class BlockCollection
    {
        public List<Block> List { get; set; }

        public Block LeftMostBlock
        {
            get
            {
                decimal min = List.Min(b => b.Location.X);
                Block result = List.Where(b => b.Location.X == min).First();
                return result;
            }
        }
        public Block RightMostBlock
        {
            get
            {
                decimal max = List.Max(b => b.Location.X);
                Block result = List.Where(b => b.Location.X == max).First();
                return result;
            }
        }

        public BlockCollection()
        {
            List = new List<Block>();
        }


    }
}

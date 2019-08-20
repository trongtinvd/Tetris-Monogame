using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class BlockCollection
    {
        public HashSet<Block> List { get; set; }
        public Block LeftMostBlock
        {
            get
            {
                Block result = List.ToArray<Block>()[0];

                foreach (Block block in List)
                {
                    if (block.Location.X < result.Location.X)
                        result = block;
                }

                return result;
            }
        }
        public Block RightMostBlock
        {
            get
            {
                Block result = List.ToArray<Block>()[0];

                foreach (Block block in List)
                {
                    if (block.Location.X > result.Location.X)
                        result = block;
                }

                return result;
            }
        }

        public BlockCollection()
        {
            List = new HashSet<Block>();
        }


    }
}

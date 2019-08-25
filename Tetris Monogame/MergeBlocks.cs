using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class MergeBlocks : BlockCollection
    {
        public int Bottom { get; internal set; }

        public MergeBlocks()
        {

        }

        public MergeBlocks(int bottom)
        {
            Bottom = bottom;
        }

        internal bool Overlapped(FallingBlock fallingBlock)
        {
            foreach (Block block1 in this.List)
            {
                foreach (Block block2 in fallingBlock.List)
                {
                    if ((int)block1.Location.X == (int)block2.Location.X && (int)block1.Location.Y == (int)block2.Location.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal void Merge(FallingBlock fallingBlock)
        {
            foreach (Block block in fallingBlock.List)
            {
                this.List.Add(block);
            }
        }


        internal void Collapse()
        {
            List<int> filledRow = (from block in List
                                   group (int)block.Location.X by (int)block.Location.Y into eachRow
                                   where eachRow.Count() >= 20
                                   select (int)eachRow.Key).ToList();

            filledRow.Sort();
            List.RemoveAll(p => filledRow.Any(y => y == (int)p.Location.Y));
            foreach (int i in filledRow)
            {
                List.Where(p => (int)p.Location.Y < i).ToList().ForEach(p => p.Location.Y++);
            }
        }

        internal bool ReachedLimit()
        {
            return List.Any(block => (int)block.Location.Y == 0);
        }
    }
}

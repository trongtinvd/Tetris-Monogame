using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class TextureManager
    {
        public FieldTexture Field { get; set; }
        public BlockTexture Block { get; set; }
        public AnnouncementBox AnnounceBox { get; set; }
        public MyFont Font { get; set; }

        public TextureManager()
        {
            Field = new FieldTexture();
            Block = new BlockTexture();
            AnnounceBox = new AnnouncementBox();
            Font = new MyFont();
        }
    }

}

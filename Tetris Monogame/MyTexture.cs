using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    abstract class MyTexture
    {
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public Rectangle DestinationRectangle { get; set; }
        public Rectangle SourceRectangle { get; set; }


        public MyTexture()
        {

        }

    }
}

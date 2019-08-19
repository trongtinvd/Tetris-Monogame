using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class MyFont
    {
        public SpriteFont Texture { get; set; }
        public Color Color { get; set; }

        public MyFont()
        {
            Color = Color.Black;
        }

        public int HorizontalPosition(string text, int containerWidth, HorizontalAlign position )
        {
            int result = 0;

            if(position==HorizontalAlign.Left)
            {
                result = 0;
            }
            else if(position==HorizontalAlign.Center)
            {
                result = (containerWidth - (int)Texture.MeasureString(text).X) / 2;
            }
            else if(position==HorizontalAlign.Right)
            {
                result = containerWidth - (int)Texture.MeasureString(text).X;
            }

            return result;
        }
    }

    enum HorizontalAlign
    {
        Center,
        Left,
        Right,
    }
}

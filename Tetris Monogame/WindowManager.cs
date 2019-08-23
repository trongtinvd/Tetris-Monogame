using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class WindowManager
    {
        public Rectangle Window { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public WindowManager()
        {
            Window = new Rectangle();
        }

        public Rectangle EntireWindow()
        {
            return Window;
        }

        public Rectangle Destination(Block block)
        {
            int blockWidth = Window.Width / Column;
            int blockHeight = Window.Height / Row;
            
            Rectangle result = new Rectangle((int)block.Location.X * blockWidth, (int)block.Location.Y * blockHeight, blockWidth, blockHeight);

            return result;
        }

        public Rectangle AnnouncementBoxDestination()
        {
            Rectangle result = new Rectangle(0, 200, Window.Width, 50);

            return result;
        }

        public Vector2 Destination(string v, MyFont font, HorizontalAlign align)
        {
            Vector2 result = new Vector2(0, 250);

            if (align == HorizontalAlign.Center)
            {
                result.X = (Window.Width - font.SpriteFont.MeasureString(v).X) / 2;
            }
            else if (align == HorizontalAlign.Left)
            {

            }
            else if (align == HorizontalAlign.Right)
            {
                result.X = (Window.Width - font.SpriteFont.MeasureString(v).X);
            }

            return result;
        }
    }
}

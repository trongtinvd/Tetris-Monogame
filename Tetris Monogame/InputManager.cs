using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class InputManager
    {
        public KeyPress EnterKey { get; set; }
        public KeyPress SpaceKey { get; set; }
        public KeyPress RightKey { get; set; }
        public KeyPress LeftKey { get; set; }
        public KeyPress UpKey { get; set; }

        public InputManager()
        {
            EnterKey = new KeyPress(Keys.Enter);
            SpaceKey = new KeyPress(Keys.Space);
            RightKey = new KeyPress(Keys.Right);
            LeftKey = new KeyPress(Keys.Left);
            UpKey = new KeyPress(Keys.Up);
        }
    }
}

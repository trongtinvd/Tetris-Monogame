using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class KeyPress
    {
        private Keys key;
        private bool isHeld;
        private static KeyboardState state;

        public KeyPress(Keys Key)
        {
            key = Key;
            isHeld = false;
        }

        public static void Update()
        {
            state = Keyboard.GetState();
        }

        public bool IsPressed()
        {
            if (state.IsKeyDown(key))
            {
                if (isHeld) return false;
                else
                {
                    isHeld = true;
                    return true;
                }
            }
            else
            {
                if (isHeld) isHeld = false;
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    class GameplayManager
    {
        public bool GameStarted { get; set; }
        public bool GamePaused { get; set; }
        public decimal GameSpeed { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public GameplayManager()
        {
            GameStarted = false;
            GamePaused = false;
        }
    }
}

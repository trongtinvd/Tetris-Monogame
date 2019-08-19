﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Tetris_Monogame
{
    class KeyboardController
    {
        public event EventHandler KeyboardTick;
        private DispatcherTimer timer;
        private HashSet<Key> pressedKeys;
        private readonly object pressedKeysLock = new object();

        public KeyboardController(Window c)
        {
            c.KeyDown += WinKeyDown;
            c.KeyUp += WinKeyUp;
            pressedKeys = new HashSet<Key>();

            timer = new DispatcherTimer();
            timer.Tick += kbTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Start();
        }

        public bool KeyDown(Key key)
        {
            lock (pressedKeysLock)
            {
                return pressedKeys.Contains(key);
            }
        }

        private void WinKeyDown(object sender, KeyEventArgs e)
        {
            lock (pressedKeysLock)
            {
                pressedKeys.Add(e.Key);
            }
        }

        private void WinKeyUp(object sender, KeyEventArgs e)
        {
            lock (pressedKeysLock)
            {
                pressedKeys.Remove(e.Key);
            }
        }

        private void kbTimer_Tick(object sender, EventArgs e)
        {
            KeyboardTick?.Invoke(this, EventArgs.Empty);
        }
    }
}

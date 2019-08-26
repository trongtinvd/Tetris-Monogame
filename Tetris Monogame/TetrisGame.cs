using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris_Monogame
{
    class TetrisGame
    {
        public SpriteBatch SpriteBatch { get; set; }

        public TextureManager TextureManager { get; set; }
        public WindowManager WindowManager { get; set; }
        public GameplayManager GameplayManager { get; set; }
        public InputManager InputManager { get; set; }

        private FallingBlock fallingBlock;
        public MergeBlocks MergeBlock { get; set; }



        public TetrisGame()
        {
            TextureManager = new TextureManager();
            WindowManager = new WindowManager();
            GameplayManager = new GameplayManager();
            InputManager = new InputManager();

            fallingBlock = new FallingBlock();
            MergeBlock = new MergeBlocks();
        }

        internal void InitializeNewGame()
        {
            fallingBlock = FallingBlockGenerator.Generate(BlocksShape.Random, new Point(this.GameplayManager.Columns/2-1, -3));
            MergeBlock = new MergeBlocks(/*MergeBlock.Bottom*/);
        }

        public void Update(KeyboardState keyboardState)
        {
            KeyPress.Update();

            if (this.GameplayManager.GameStarted == true)
            {

                if (this.InputManager.LeftKey.IsPressed() && fallingBlock.LeftSideIsFree(MergeBlock))
                {
                    fallingBlock.MoveLeft(1);
                }
                else if (this.InputManager.RightKey.IsPressed() && fallingBlock.RightSideIsFree(MergeBlock))
                {
                    fallingBlock.MoveRight(1);
                }
                else if (this.InputManager.UpKey.IsPressed())
                {
                    fallingBlock.Transform();
                }
                else if (this.InputManager.EnterKey.IsPressed())
                {
                    this.GameplayManager.GameStarted = false;
                }

                fallingBlock.AdjustHorizontalPosition(0, this.GameplayManager.Columns);
                fallingBlock.MoveDown(this.GameplayManager.GameSpeed);


                if (MergeBlock.Overlapped(fallingBlock) || fallingBlock.BelowBottom(GameplayManager.Rows-1))
                {
                    fallingBlock.MoveBack();
                    MergeBlock.Merge(fallingBlock);
                    fallingBlock = FallingBlockGenerator.Generate(BlocksShape.Random, new Point(this.GameplayManager.Columns/2-1, -3));


                    MergeBlock.Collapse(this.GameplayManager.Columns);

                    if (MergeBlock.ReachedLimit())
                    {
                        this.GameplayManager.GameStarted = false;
                    }
                }
            }
            else
            {
                if (this.InputManager.EnterKey.IsPressed())
                {
                    this.GameplayManager.GameStarted = true;
                    InitializeNewGame();
                }
            }
        }

        public void Draw()
        {
            DrawField();
            DrawFallingBlock();
            DrawMergeBlock();

            if (this.GameplayManager.GameStarted == false)
            {
                DrawAnnounce();
            }

        }

        private void DrawField()
        {
            SpriteBatch.Draw(this.TextureManager.Field.Texture, this.WindowManager.EntireWindow(), this.TextureManager.Field.Source, Color.White);
        }

        private void DrawFallingBlock()
        {
            foreach (Block block in fallingBlock.List)
            {
                SpriteBatch.Draw(this.TextureManager.Block.Texture, this.WindowManager.Destination(block, this.GameplayManager), this.TextureManager.Block.Source(block), Color.White);
            }
        }

        private void DrawMergeBlock()
        {
            foreach (Block block in MergeBlock.List)
            {
                SpriteBatch.Draw(this.TextureManager.Block.Texture, this.WindowManager.Destination(block, this.GameplayManager), this.TextureManager.Block.Source(block), Color.White);
            }
        }

        private void DrawAnnounce()
        {
            SpriteBatch.Draw(this.TextureManager.AnnounceBox.Texture, this.WindowManager.AnnouncementBoxDestination(), Color.White);
            SpriteBatch.DrawString(this.TextureManager.Font.SpriteFont, "Press enter", this.WindowManager.Destination("Press enter", this.TextureManager.Font, HorizontalAlign.Center), Color.Black);
        }
    }
}

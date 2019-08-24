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
        private MergeBlocks mergeBlock;



        public TetrisGame()
        {
            TextureManager = new TextureManager();
            WindowManager = new WindowManager();
            GameplayManager = new GameplayManager();
            InputManager = new InputManager();

            fallingBlock = new FallingBlock();
            mergeBlock = new MergeBlocks();
        }

        internal void InitializeNewGame()
        {
            fallingBlock = FallingBlockGenerator.Generate(BlocksShape.Random, new Point(8,0));
            mergeBlock = new MergeBlocks();
        }

        public void Update(KeyboardState keyboardState)
        {
            KeyPress.Update();

            if (this.GameplayManager.GameStarted == true)
            {
                //    if(mergeBlock.Collision(fallingBlock))
                //    {
                //        mergeBlock.Merge(fallingBlock);
                //        fallingBlock = new FallingBlock(Blocks.Texture);

                //        if(mergeBlock.CanCollapse())
                //        {
                //            mergeBlock.Collapse();
                //        }

                //        if(mergeBlock.ReachedLimit())
                //        {
                //            this.GameplayManager.GameStarted = false;
                //        }
                //    }

                if (this.InputManager.LeftKey.isPressed())
                {
                    fallingBlock.MoveLeft(1);
                }
                else if (this.InputManager.RightKey.isPressed())
                {
                    fallingBlock.MoveRight(1);
                }
                else if (this.InputManager.UpKey.isPressed())
                {
                    fallingBlock.Transform();
                }
                else if (this.InputManager.EnterKey.isPressed())
                {
                    this.GameplayManager.GameStarted = false;
                }

                fallingBlock.Adjust(0, WindowManager.Column);
                fallingBlock.MoveDown(this.GameplayManager.GameSpeed);
            }
            else
            {
                if (this.InputManager.EnterKey.isPressed())
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

        private void DrawFallingBlock( )
        {
            foreach (Block block in fallingBlock.List)
            {
                SpriteBatch.Draw(this.TextureManager.Block.Texture, this.WindowManager.Destination(block), this.TextureManager.Block.Source(block), Color.White);
            }
        }

        private void DrawMergeBlock( )
        {
            foreach (Block block in mergeBlock.List)
            {
                SpriteBatch.Draw(this.TextureManager.Block.Texture, this.WindowManager.Destination(block), this.TextureManager.Block.Source(block), Color.White);
            }
        }

        private void DrawAnnounce( )
        {
            SpriteBatch.Draw(this.TextureManager.AnnounceBox.Texture, this.WindowManager.AnnouncementBoxDestination(), Color.White);
            SpriteBatch.DrawString(this.TextureManager.Font.SpriteFont, "Press enter", this.WindowManager.Destination("Press enter", this.TextureManager.Font, HorizontalAlign.Center), Color.Black);
        }
    }
}

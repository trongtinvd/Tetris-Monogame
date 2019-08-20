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
        //public int WindowHeight { get; set; }
        //public int WindowWidth { get; set; }
        //public int GameSpeed { get; set; }
        //public bool Started { get; set; }

        public TextureManager TextureManager { get; set; }
        public WindowManager WindowManager { get; set; }
        public GameplayManager GameplayManager { get; set; }
        public KeyboardManager KeyboardManager { get; set; }


        //public FieldTexture Field { get; set; }
        //public AnnouncementBox AnnounceBox { get; set; }
        //public MyFont Font { get; set; }

        private FallingBlock fallingBlock;
        private MergeBlocks mergeBlock;



        public TetrisGame()
        {
            //WindowHeight = 0;
            //WindowWidth = 0;
            //Started = false;
            //Field = new FieldTexture();
            //AnnounceBox = new AnnouncementBox();
            //Font = new MyFont();
        }

        internal void InitializeNewGame()
        {
            fallingBlock = new FallingBlock(BlocksShape.Random);
            //mergeBlocks = new MergeBlocks();
        }

        internal void InitializeWindow()
        {
            //Field.DestinationRectangle = new Rectangle(0, 0, WindowWidth, WindowHeight);
            //Field.SourceRectangle = new Rectangle(142, 81, 521 - 142, 542 - 81);
            //Field.Color = Color.White;

            //AnnounceBox.DestinationRectangle = new Rectangle(0, 200, WindowWidth, 50);
            //AnnounceBox.Color = Color.White;

            //Font.Color = Color.Black;
        }

        public void Update(KeyboardState keyboardState)
        {
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

                if(keyboardState.IsKeyDown(Keys.Left)&&fallingBlock.LeftMostBlock.Location.X!=0)
                {
                    fallingBlock.MoveLeft();
                }
                else if (keyboardState.IsKeyDown(Keys.Right)&& fallingBlock.RightMostBlock.Location.X!=9)
                {
                    fallingBlock.MoveRight();
                }
                else if(keyboardState.IsKeyDown(Keys.Up))
                {
                    fallingBlock.Rotate90DegreeClockwire();
                }

                fallingBlock.MoveDown(this.GameplayManager.GameSpeed);
            }
            else
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    this.GameplayManager.GameStarted = true;
                    InitializeNewGame();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(this.TextureManager.Field.Texture, this.WindowManager.EntireWindow, this.TextureManager.Field.Source, Color.White);

            foreach(Block block in fallingBlock.List)
            {
                spriteBatch.Draw(this.TextureManager.GetTexture(block), this.WindowManager.GetBlockDestination(block), Color.White);
            }
            //foreach (Block block in mergeBlock.List)
            //{
            //  spriteBatch.Draw(this.TextureManager.GetTexture(block), this.WindowManager.GetBlockDestination(block), Color.White);
            //}

            if (this.GameplayManager.GameStarted == false)
            {
                //spriteBatch.Draw(AnnounceBox.Texture, AnnounceBox.DestinationRectangle, AnnounceBox.Color);
                //spriteBatch.DrawString(Font.Texture, "Press enter", new Vector2(Font.HorizontalPosition("Press enter", WindowWidth, HorizontalAlign.Center), 250), Font.Color);
                spriteBatch.Draw(this.TextureManager.AnnounceBox.Texture, this.WindowManager.GetAnnounceBoxDestination(), Color.White);
                spriteBatch.DrawString(this.TextureManager.Font.SpriteFont, "Press enter", this.WindowManager.GetMessageDestination("Press enter"), Color.Black);
            }
            
        }
    }
}

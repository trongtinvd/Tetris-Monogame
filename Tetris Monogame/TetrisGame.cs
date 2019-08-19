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
        public int WindowHeight { get; set; }
        public int WindowWidth { get; set; }
        public bool Started { get; set; }

        public FieldTexture Field { get; set; }
        //public BlocksTexture Blocks { get; set; }
        public AnnouncementBox AnnounceBox { get; set; }
        public MyFont Font { get; set; }

        //private FallingBlock fallingBlock;
        //private MergeBlock mergeBlock;



        public TetrisGame()
        {
            WindowHeight = 0;
            WindowWidth = 0;
            Started = false;
            Field = new FieldTexture();
            AnnounceBox = new AnnouncementBox();
            Font = new MyFont();
        }

        internal void InitializeNewGame()
        {
            //fallingBlock = new FallingBlock(Blocks.Texture);

            Field.DestinationRectangle = new Rectangle(0, 0, WindowWidth, WindowHeight);
            Field.SourceRectangle = new Rectangle(142, 81, 521 - 142, 542 - 81);
            Field.Color = Color.White;

            AnnounceBox.DestinationRectangle = new Rectangle(0, 200, WindowWidth, 50);
            AnnounceBox.Color = Color.White;

            Font.Color = Color.Black;
        }

        public void Update(KeyboardState keyboardState)
        {
            if (Started == true)
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
                //            Started = false;
                //        }
                //    }

                //    fallingBlock.Transform(keyboardState);
                //    fallingBlock.Move();
            }
            else
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    Started = true;
                    InitializeNewGame();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(Field.Texture, Field.DestinationRectangle, Field.SourceRectangle, Field.Color);

            //foreach(Block block in fallingBlock.List)
            //{
            //    spriteBatch.Draw(block.Texture, block.DestinationRectangle, block.Color);
            //}
            //foreach (Block block in mergeBlock.List)
            //{
            //    spriteBatch.Draw(block.Texture, block.DestinationRectangle, block.Color);
            //}

            if (Started == false)
            {
                spriteBatch.Draw(AnnounceBox.Texture, AnnounceBox.DestinationRectangle, AnnounceBox.Color);
                spriteBatch.DrawString(Font.Texture, "Press enter", new Vector2(Font.HorizontalPosition("Press enter", WindowWidth, HorizontalAlign.Center), 250), Font.Color);
            }

            spriteBatch.End();
        }
    }
}

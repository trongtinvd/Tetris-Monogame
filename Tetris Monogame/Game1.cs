using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris_Monogame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TetrisGame game;
        int windowHeight = 600;
        int windowWidth = 360;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;
        }

        
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            game = new TetrisGame();
            game.WindowHeight = windowHeight;
            game.WindowWidth = windowWidth;
            game.Field.Texture = Content.Load<Texture2D>("Field");
            //game.Blocks.Texture = Content.Load<Texture2D>("Blocks");
            game.AnnounceBox.Texture = Content.Load<Texture2D>("AnnounceBox");
            game.Font.Texture = Content.Load<SpriteFont>("ArialFont");

            game.InitializeNewGame();
        }
        
        protected override void UnloadContent()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            game.Update(Keyboard.GetState());

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            
            game.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}

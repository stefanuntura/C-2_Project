using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Graduation_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D playerSprite;
        Texture2D playerLeftSprite;
        Texture2D floorSprite;

        SpriteFont font;

        int screenWidth;
        int screenHeight;

        Player player = new Player();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playerSprite = Content.Load<Texture2D>("player");
            floorSprite = Content.Load<Texture2D>("caveFloorFull");
            playerLeftSprite = Content.Load<Texture2D>("playerL");
            font = Content.Load<SpriteFont>("timerFont");

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.playerUpdate(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            _spriteBatch.Begin();

            // Draws Player facing éither left or right
            if(player.getIsFacingRight() == true)
            {
                _spriteBatch.Draw(playerSprite, new Vector2(player.getPosition().X - 15, player.getPosition().Y - 25), Color.White);
            }
            else
            {
                _spriteBatch.Draw(playerLeftSprite, new Vector2(player.getPosition().X - 15, player.getPosition().Y - 25), Color.White);
            }
            
            // Draws floor 
            for (int position = 0; position <= 1280; position += 32)
            {
                _spriteBatch.Draw(floorSprite, new Vector2(position -16, screenHeight - 32), Color.White);
            }

            _spriteBatch.DrawString(font, player.vy.ToString(), new Vector2(100, 100), Color.Black);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Graduation_Game.Entities;
using Graduation_Game.TestMap;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Graduation_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //TiledMap _tiledMap;
        //TiledMapRenderer _tiledMapRenderer;

        private Player _player;
        private Map _map;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player = new Player(this, new Vector2(0, 0));
            _map = new Map();
            _map.addBox(new Box(this, new Vector2(800, 40), new Vector2(0, 440), Color.DarkSlateGray));
            _map.addBox(new Box(this, new Vector2(20, 700), new Vector2(780, 0), Color.DarkSlateGray));
            _map.addBox(new Box(this, new Vector2(40, 400), new Vector2(740, 380), Color.DarkSlateGray));
            _map.addBox(new Box(this, new Vector2(50, 400), new Vector2(690, 405), Color.DarkSlateGray));
            _map.addBox(new Box(this, new Vector2(50, 15), new Vector2(100, 300), Color.DarkGray));
            _map.addBox(new Box(this, new Vector2(50, 15), new Vector2(300, 350), Color.DarkGray));
            _map.addBox(new Box(this, new Vector2(50, 15), new Vector2(200, 380), Color.DarkGray));
            _map.addBox(new Box(this, new Vector2(60, 15), new Vector2(440, 400), Color.DarkGray));
            _map.LoadContent(this);

            // _tiledMap = Content.Load<TiledMap>("Map/test");
            // _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //_tiledMapRenderer.Update(gameTime);
            _player.Update(gameTime, _map);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here

            //_tiledMapRenderer.Draw();
            _player.Draw(_spriteBatch, gameTime);
            _map.Draw(_spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}

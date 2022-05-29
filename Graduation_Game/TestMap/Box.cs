﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Graduation_Game.Graphics;


namespace Graduation_Game.TestMap
{
    public class Box : DrawableGameComponent
    {
        public Vector2 Dimensions { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture;

        public Box(Game game, Vector2 dimensions, Vector2 position) : base(game)
        {
            Dimensions = dimensions;
            Position = position;
        }

        public void LoadContent(Game game)
        {
            Texture = new Texture2D(GraphicsDevice, 1, 1);
            Texture.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, (int)Dimensions.X, (int)Dimensions.Y), Color.Chocolate);
            spriteBatch.End();
        }
    }
}
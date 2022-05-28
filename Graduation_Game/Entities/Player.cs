using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Graduation_Game.Graphics;

namespace Graduation_Game.Entities
{
    public class Player : Entity
    {

        private double timer;
        InputController controller;
        Dictionary<String, Sprite> animations;
        float dt;

        public Player(Game game, Vector2 position) : base(game, position)
        {
            animations = new Dictionary<String, Sprite>();
            LoadContent(game);
            Sprite = animations["walk_right"];
            Speed = 180;
            controller = new InputController(this);
        }

        public void Update(GameTime gameTime)
        {
            // jumping-timer
            timer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            // delta time
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // update velocity on Y axis
            Gravity = Gravity < Speed * 1.5 ? Gravity + 7.5 : Gravity;

            controller.handleInput();

            float newY = Position.Y + Gravity * dt < 400 ? Position.Y + (float)Gravity * dt : 400;
            Position = new Vector2(Position.X, newY);
        }

        public void moveRight()
        {
            Sprite = animations["walk_right"];
            if (Position.X < 1265)
            {
                Position = new Vector2(Position.X + (float)Speed * dt, Position.Y);
            }
        }

        public void moveLeft()
        {
            Sprite = animations["walk_left"];
            if (Position.X > 0)
            {
                Position = new Vector2(Position.X - (float)Speed * dt, Position.Y);
            }
        }

        public void moveUp()
        {
            if (timer <= 0)
            {
                Gravity = -Speed * 1.5f;
                timer = 1200;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public void LoadContent(Game game)
        {
            animations["walk_right"] = new Sprite(game.Content.Load<Texture2D>("Player/player"));
            animations["walk_left"] = new Sprite(game.Content.Load<Texture2D>("Player/playerL"));
        }
    }
}
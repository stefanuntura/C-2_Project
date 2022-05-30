using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Graduation_Game.Graphics;
using Graduation_Game.TestMap;

namespace Graduation_Game.Entities
{
    public class Player : Entity
    {

        private bool _canJump = false;
        private InputController controller;
        private Dictionary<String, Sprite> animations;
        private float dt;

        public Player(Game game, Vector2 position) : base(game, position)
        {
            animations = new Dictionary<String, Sprite>();
            LoadContent(game);
            Sprite = animations["walk_right"];
            Speed = 180;
            controller = new InputController(this);
        }

        public void Update(GameTime gameTime, Map map)
        {
            // delta time
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            controller.handleInput(map);
            moveY(map);
        }

        public void moveRight(Map map)
        {
            Sprite = animations["walk_right"];
            if (Position.X < 1265)
            {
                bool collision = false;
                Box collidedBox = null;
                Vector2 newPos = new Vector2(Position.X + (float)Speed * dt, Position.Y);

                foreach (Box box in map.Boxes)
                {
                    if (collided(box, newPos))
                    {
                        collision = true;
                        collidedBox = box;
                        break;
                    }
                }

                if (!collision)
                {
                    Position = newPos;
                }
                else
                {
                    Position = new Vector2(collidedBox.Position.X - Sprite.Texture.Width - 1, Position.Y);
                }
            }
        }

        public void moveLeft(Map map)
        {
            Sprite = animations["walk_left"];
            if (Position.X > 0)
            {
                bool collision = false;
                Box collidedBox = null;
                Vector2 newPos = new Vector2(Position.X - (float)Speed * dt, Position.Y);

                foreach (Box box in map.Boxes)
                {
                    if (collided(box, newPos))
                    {
                        collision = true;
                        collidedBox = box;
                        break;
                    }
                }

                if (!collision)
                {
                    Position = newPos;
                }
                else
                {
                    Position = new Vector2(collidedBox.Position.X + collidedBox.Dimensions.X + 1, Position.Y);
                }
            }
        }

        public void moveY(Map map)
        {
            Gravity = Gravity < Speed * 1.5 ? Gravity + 7.5 : Gravity;

            if (Position.Y + Gravity * dt < 400)
            {
                bool collision = false;
                Box collidedBox = null;
                Vector2 newPos = new Vector2(Position.X, Position.Y + (float)Gravity * dt);

                foreach (Box box in map.Boxes)
                {
                    if (collided(box, newPos))
                    {
                        collision = true;
                        collidedBox = box;
                        break;
                    }
                }

                if (!collision)
                {
                    Position = newPos;
                    _canJump = false;
                }
                else
                {
                    if (Gravity < 0)
                    {
                        Position = new Vector2(Position.X, collidedBox.Position.Y + collidedBox.Dimensions.Y + 1);
                        Gravity = 0;
                    }
                    else
                    {
                        Position = new Vector2(Position.X, collidedBox.Position.Y - Sprite.Texture.Height - 1);
                        _canJump = true;
                    }
                }
            }
            else
            {
                Position = new Vector2(Position.X, 400);
                _canJump = true;
            }
        }

        public void jump()
        {
            if (_canJump)
            {
                Gravity = -Speed * 1.5f;
                _canJump = false;
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

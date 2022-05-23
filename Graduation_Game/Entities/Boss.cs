using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Graduation_Game.Graphics;

namespace Graduation_Game.Entities
{
    public abstract class Boss : Entity
    {
        public Sprite Sprite { get; private set; }
        public EntityState State { get; private set; }
        public Vector2 Position { get; set; }
        public double Health { get; set; }
        public double Speed { get; set; }
        public double Gravity { get; set; }
        public double Damage { get; set; }
        public int DrawOder { get; set; }

        public Boss(Texture2D spriteSheet, Vector2 position)
        {
            Sprite = new Sprite(spriteSheet);
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Sprite.Draw(spriteBatch, this.Position);
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}

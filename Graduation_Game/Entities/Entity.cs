using Microsoft.Xna.Framework;
using Graduation_Game.Graphics;
using Graduation_Game.TestMap;
using System.Diagnostics;

namespace Graduation_Game.Entities
{
    public abstract class Entity : DrawableGameComponent
    {

        public Sprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Dimensions { get; set; }
        public double Health { get; set; }
        public double Speed { get; set; }
        public double Gravity { get; set; }
        public double Damage { get; set; }

        public Entity(Game game, Vector2 position) : base(game)
        {
            Position = position;
        }

        public bool collided(Box box, Vector2 newPos)
        {
            if (newPos.Y <= box.Position.Y + box.Dimensions.Y && newPos.Y + Sprite.Texture.Height >= box.Position.Y)
            {
                if (newPos.X <= box.Position.X + box.Dimensions.X && newPos.X + Sprite.Texture.Width >= box.Position.X)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
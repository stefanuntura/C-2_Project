using Microsoft.Xna.Framework;
using Graduation_Game.Graphics;

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
    }
}
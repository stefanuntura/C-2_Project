using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graduation_Game.Entities
{
    interface Entity
    {
        int DrawOder { get; }

        double Health { get; }
        double Speed { get; }
        double Gravity { get; }
        double Damage { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}

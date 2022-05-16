using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Graduation_Game
{
    class Player
    {
        private Vector2 position = new Vector2(15, 662);
        private int speed = 180;
        private double health;
        public float vy;
        private double jumpingTimer;


        public bool isFacingRight = true;

        public Vector2 getPosition()
        {
            return this.position;
        }

        public void setPosition(Vector2 vec)
        {
            this.position = vec;
        }

        public void playerUpdate(GameTime gameTime)
        {
            // subtracting elapsed time from jump cooldown
            jumpingTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;

            KeyboardState kState = Keyboard.GetState();

            //delta time
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //update velocity on Y axis
            this.vy = this.vy < speed * 1.5 ? this.vy + 7.5f : this.vy;

            //check if player above ground
            if(position.Y + this.vy * dt < 662)
            {
                position.Y += this.vy * dt;
            }
            else
            {
                position.Y = 662;
            }

            //checking keystates
            if (kState.IsKeyDown(Keys.Right) && position.X < 1265)
            {
                position.X += speed * dt;
                isFacingRight = true; 
            }
            if (kState.IsKeyDown(Keys.Left) && position.X > 15)
            {
                position.X -= speed * dt;
                isFacingRight = false ;
            }
            if (kState.IsKeyDown(Keys.Up))
            {
                // check if jump cooldown has expired
                if (jumpingTimer <= 0)
                {
                    this.vy = -speed * 1.5f;
                    jumpingTimer = 1200;
                }
                //position.Y -= speed * dt;
                
            }
            if(position.Y > 662)
            {
                position.Y = 662;

            }
                
            

        }

        public bool getIsFacingRight()
        {
            return isFacingRight;
        }
    }
}

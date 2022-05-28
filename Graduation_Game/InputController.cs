using Graduation_Game.Entities;
using Microsoft.Xna.Framework.Input;

namespace Graduation_Game
{
    class InputController
    {
        private Player _player;
        private KeyboardState _kState;

        public InputController(Player player)
        {
            _player = player;
        }

        public void handleInput()
        {
            _kState = Keyboard.GetState(); ;
            Keys[] keys = _kState.GetPressedKeys();

            foreach (Keys key in keys)
            {
                switch (key)
                {
                    case Keys.Right:
                        _player.moveRight();
                        break;
                    case Keys.Left:
                        _player.moveLeft();
                        break;
                    case Keys.Up:
                        _player.moveUp();
                        break;
                }
            }
        }
    }
}
using Graduation_Game.Entities;
using Microsoft.Xna.Framework.Input;
using Graduation_Game.TestMap;

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

        public void handleInput(Map map)
        {
            _kState = Keyboard.GetState(); ;
            Keys[] keys = _kState.GetPressedKeys();

            foreach (Keys key in keys)
            {
                switch (key)
                {
                    case Keys.D:
                        _player.moveRight(map);
                        break;
                    case Keys.A:
                        _player.moveLeft(map);
                        break;
                    case Keys.W:
                        _player.jump();
                        break;
                }
            }
        }
    }
}
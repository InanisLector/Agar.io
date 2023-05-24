using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Agar.io.scripts.Extentions.Vector2Extention;

namespace Agar.io.scripts.Game_elements.PlayerInput
{
    public class PlayerMouseInput : IInput
    {
        private RenderWindow _window;

        public PlayerMouseInput(RenderWindow window)
        {
            _window = window;
        }

        public Vector2f GetInput()
            => GetMouseInput();

        private Vector2f GetMouseInput()
            => ((Vector2f)(Mouse.GetPosition(_window) - (Vector2i)_window.Size / 2)).Normalize();
    }

    public interface IInput
    {
        public Vector2f GetInput();
    }
}

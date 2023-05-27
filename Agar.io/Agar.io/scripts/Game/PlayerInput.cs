using SFML.Graphics;
using SFML.System;
using SFML.Window;
using AgarIO.scripts.GameEngine;

namespace AgarIO.scripts.Game
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

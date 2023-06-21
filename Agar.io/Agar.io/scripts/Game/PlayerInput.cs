using SFML.Graphics;
using SFML.System;
using AgarIO.scripts.GameEngine;
using AgarIO.scripts.GameEngine.Input;

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
        {
            Vector2f cur = ((Vector2f)(InputSystem.MousePosition - (Vector2i)_window.Size / 2)).Normalize();

            Console.WriteLine(cur);
                
            return cur;
        }
    }

    public interface IInput
    {
        public Vector2f GetInput();
    }
}

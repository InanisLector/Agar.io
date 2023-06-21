using SFML.System;

namespace AgarIO.scripts.Game
{
    public class NullInput : IInput
    {
        public Vector2f GetInput()
            => new Vector2f(0, 0);
    }
}

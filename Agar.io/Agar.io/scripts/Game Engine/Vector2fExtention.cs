using SFML.System;

namespace AgarIO.scripts.GameEngine
{
    public static class Vector2fExtention
    {
        public static Vector2f Normalize(this Vector2f vector)
        {
            if (vector == new Vector2f(0, 0)) 
                return vector;

            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

            return new Vector2f(vector.X / magnitude, vector.Y / magnitude);
        }
    }
}

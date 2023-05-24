using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agar.io.scripts.Extentions.Vector2Extention
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

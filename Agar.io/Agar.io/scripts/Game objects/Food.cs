using AgarIO.scripts.GameElements.GameObject;
using SFML.Graphics;
using SFML.System;
using AgarIO.scripts.Game;

namespace AgarIO.scripts.GameObjects.Food
{
    public class Food : GameObject
    {
        public readonly int Mass;

        public Food(int mass, Vector2f position)
        {
            Mass = mass;
            this.position = position;

            Sprite = new CircleShape(1, 30);
            Sprite.FillColor = Color.Green;
            Sprite.OutlineColor = Color.White;
        }

        public static Food CreateFood()
        {
            Random rand = new();

            return new Food(rand.Next(10, 20), new Vector2f(rand.Next((int)Agario.windowWidth), rand.Next((int)Agario.windowHeight)));
        }
    }
}

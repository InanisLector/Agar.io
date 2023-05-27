using SFML.Graphics;
using SFML.System;
using AgarIO.scripts.GameEngine;

namespace AgarIO.scripts.Game
{
    public class Food : GameObject, IMass
    {
        private readonly int mass;

        public Food(int mass, Vector2f position)
        {
            this.mass = mass;
            this.position = position;
        }

        public static Food CreateFood()
        {
            Random rand = new();

            return new Food(rand.Next(1, 5), new Vector2f(rand.Next((int)GameEngine.Game.windowWidth), rand.Next((int)GameEngine.Game.windowHeight)));
        }

        public override void Awake()
        {
            base.Awake();

            Sprite = new CircleShape(1, 30);
            Sprite.FillColor = Color.Green;
            Sprite.OutlineColor = Color.White;
        }

        public int GetMass()
            => mass;

        public void GetEaten()
            => Destroy();
    }
}

using SFML.Graphics;
using SFML.System;
using AgarIO.scripts.GameEngine;
using Random = AgarIO.scripts.GameEngine.Random;

namespace AgarIO.scripts.Game
{
    public class Food : GameObject, IMass
    {
        private readonly int mass;

        public Food(int mass, Vector2f position)
        {
            this.mass = mass;
            this.position = position;

            tags.Add("food");
        }

        public static Food CreateFood()
        {
            return new Food(Random.Int(1, 5), new Vector2f(Random.Int((int)GameEngine.Game.windowWidth), Random.Int((int)GameEngine.Game.windowHeight)));
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
        {
            CreateFood();
            Destroy();
        }
    }
}

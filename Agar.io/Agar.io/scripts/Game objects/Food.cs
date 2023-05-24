using AgarIO.scripts.GameElements.GameObject;
using SFML.Graphics;
using SFML.System;
using AgarIO.scripts.Game;
using Agar.io.scripts.Game_elements;

namespace AgarIO.scripts.GameObjects.Food
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

            return new Food(rand.Next(10, 20), new Vector2f(rand.Next((int)Agario.windowWidth), rand.Next((int)Agario.windowHeight)));
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

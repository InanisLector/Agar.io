using AgarIO.scripts.Game;
using AgarIO.scripts.GameElements.GameObject;
using SFML.Graphics;
using SFML.System;

namespace AgarIO.scripts.GameObjects.Player
{
    public class Player : GameObject
    {
        public int Mass { get; private set; } = 100;

        public Player(Vector2f position)
        {
            this.position = position;
        }

        public static Player CreatePlayer()
        {
            Random rand = new();

            return new Player(new Vector2f(rand.Next((int)Agario.windowWidth), rand.Next((int)Agario.windowHeight)));
        }

        public override void Awake()
        {
            base.Awake();

            Shape sprite = new CircleShape(1, 30);
            sprite.FillColor = Color.Magenta;
            sprite.OutlineColor = Color.White;
            float scale = Mass / 10;
            sprite.Scale = new Vector2f(scale, scale);

            Sprite = sprite;
        }
    }
}

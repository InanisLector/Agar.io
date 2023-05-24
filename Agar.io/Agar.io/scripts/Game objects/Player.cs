using Agar.io.scripts.Game_elements;
using Agar.io.scripts.Game_elements.PlayerInput;
using AgarIO.scripts.Game;
using AgarIO.scripts.GameElements.GameObject;
using AgarIO.scripts.GameElements.Time;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AgarIO.scripts.GameObjects.Player
{
    public class Player : GameObject, IMass
    {
        private int mass = 100;

        private const float constSpeed = 100f;

        private IInput inputSystem;
        private Vector2f input => inputSystem.GetInput();

        public Player(Vector2f position, IInput inputSystem)
        {
            this.position = position;
            this.inputSystem = inputSystem;
        }

        public static Player CreatePlayer(IInput inputSystem)
        {
            Random rand = new();

            return new Player(new Vector2f(rand.Next((int)Agario.windowWidth), rand.Next((int)Agario.windowHeight)), inputSystem);
        }

        public override void Awake()
        {
            base.Awake();
            
            Sprite = CreateScaledSprite(mass / 10); ;
        }

        private Shape CreateScaledSprite(float scale)
        {
            Shape sprite = new CircleShape(1, 30);
            sprite.FillColor = Color.Magenta;
            sprite.OutlineColor = Color.White;
            sprite.Scale = new Vector2f(scale, scale);
            return sprite;
        }

        public override void Update()
        {
            base.Update();

            TryEat(GameObjectLoop.GetInstance().GetCollisions(this));

            Move();
        }

        private void TryEat(GameObject[] gameObjects)
        {
            foreach (GameObject obj in gameObjects)
            {
                int mass = ((IMass)obj).GetMass();

                if (mass < this.mass * 0.75f)
                {
                    this.mass += mass;

                    Sprite = CreateScaledSprite(this.mass / 10f);

                    Console.WriteLine(Sprite.Scale);

                    ((IMass)obj).GetEaten();
                }
            }
        }

        public int GetMass()
            => mass;

        public void GetEaten()
            => Destroy();

        private void Move()
        {
            float speed = 1f / mass;

            Vector2f currentPosition = position + input * constSpeed * speed * STime.deltaTime;
            position = ClampPosition(currentPosition);
        }

        private Vector2f ClampPosition(Vector2f currentPosition)
        {
            currentPosition.X = currentPosition.X < 0 ?
                0 :
                currentPosition.X;

            currentPosition.X = currentPosition.X > Agario.windowWidth ?
                Agario.windowWidth :
                currentPosition.X;

            currentPosition.Y = currentPosition.Y < 0 ?
                0 :
                currentPosition.Y;

            currentPosition.Y = currentPosition.Y > Agario.windowHeight ?
                Agario.windowWidth :
                currentPosition.Y;

            return currentPosition;
        }
    }
}

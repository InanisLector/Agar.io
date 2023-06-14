using AgarIO.scripts.GameEngine;
using SFML.Graphics;

namespace AgarIO.scripts.Game
{
    public class Camera : GameObject
    {
        public View view { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        private GameObject objectToFollow;
        private readonly RenderWindow window;

        public Camera(GameObject objectToFollow, int width, int heigth)
        {
            window = GameEngine.Game.window;

            this.objectToFollow = objectToFollow;
            IsCollideable = false;
            IsRendered = false;

            Width = width;
            Height = heigth;

            view = new(new FloatRect(width / 2f, heigth / 2f, width, heigth));
        }
        public override void Update()
        {
            window.SetView(view);
            view.Center = objectToFollow.position;
        }
    }
}

using Agar.io.scripts.Game_elements.Time;
using Agar.io.scripts.Game_objects.Food;
using Gameobject;
using SFML.Graphics;
using SFML.Window;

namespace Agar.io.scripts.Game
{
    public class AgarIO
    {
        private GameObjectLoop loop;
        
        private RenderWindow window;
        public const uint windowWidth = 1600;
        public const uint windowHeight = 900;

        public AgarIO()
        {
            window = new(new VideoMode(windowWidth, windowHeight), "Agar.io");

            loop = GameObjectLoop.GetInstance();
        }

        public void StartGame()
        {
            STime.Innit();

            InnitObjects();
            GameLoop();
        }

        private void InnitObjects()
        {
            for (int i = 0; i < 500; i++)
                Food.CreateFood();
        }

        private void GameLoop()
        {
            bool isInGame = true;

            while (isInGame)
            {
                loop.InvokeAwake();
                loop.InvokeUpdate();
                loop.InvokeRender(window);
            }
        }
    }
}

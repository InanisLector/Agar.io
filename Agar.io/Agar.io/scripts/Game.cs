using AgarIO.scripts.GameElements.Time;
using AgarIO.scripts.GameObjects.Food;
using AgarIO.scripts.GameElements.GameObject;
using SFML.Graphics;
using SFML.Window;

namespace AgarIO.scripts.Game
{
    public class Agario
    {
        private GameObjectLoop loop;
        
        private RenderWindow window;
        public const uint windowWidth = 1600;
        public const uint windowHeight = 900;

        public Agario()
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
                STime.ElapseTime();

                loop.InvokeAwake();
                loop.InvokeUpdate();
                loop.InvokeRender(window);
            }
        }
    }
}

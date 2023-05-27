using AgarIO.scripts.GameEngine;
using SFML.Graphics;
using SFML.Window;

namespace AgarIO.scripts.GameEngine
{
    public class Game
    {
        private GameObjectLoop loop;
        
        public static RenderWindow window { get; private set; } 
            = new (new VideoMode(windowWidth, windowHeight), "Game");
        public const uint windowWidth = 1600;
        public const uint windowHeight = 900;

        public Game()
        {
            loop = GameObjectLoop.GetInstance();
        }

        public void StartGame(IScene scene)
        {
            STime.Innit();

            scene.StartScene();

            CameraInnit();
            GameLoop();
        }

        private void CameraInnit()
        {
            window.SetFramerateLimit(144);
            window.Closed += WindowClosed;
        }

        private void GameLoop()
        {
            bool isInGame = true;

            while (isInGame)
            {
                STime.ElapseTime();
                window.DispatchEvents();

                loop.InvokeAwake();
                loop.InvokeUpdate();
                loop.InvokeRender(window);
            }
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
    }
}

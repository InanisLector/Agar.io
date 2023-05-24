using AgarIO.scripts.GameElements.Time;
using AgarIO.scripts.GameObjects.Food;
using AgarIO.scripts.GameElements.GameObject;
using SFML.Graphics;
using AgarIO.scripts.GameObjects.Player;
using Agar.io.scripts.Game_elements.PlayerInput;
using SFML.Window;

namespace AgarIO.scripts.Game
{
    public class Agario
    {
        private GameObjectLoop loop;
        
        public RenderWindow window { get; private set; }
        public const uint windowWidth = 1600;
        public const uint windowHeight = 900;

        public Agario()
        {
            loop = GameObjectLoop.GetInstance();
        }

        public void StartGame()
        {
            STime.Innit();

            CameraInnit();
            InnitObjects();
            GameLoop();
        }

        private void CameraInnit()
        {
            window = new(new VideoMode(windowWidth, windowHeight), "Agar.io");
            window.SetFramerateLimit(144);
            window.Closed += WindowClosed;
        }

        private void InnitObjects()
        {
            Player.CreatePlayer(new PlayerMouseInput(window));

            for (int i = 0; i < 500; i++)
                Food.CreateFood();
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

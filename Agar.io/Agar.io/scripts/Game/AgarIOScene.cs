using AgarIO.scripts.GameEngine;

namespace AgarIO.scripts.Game
{
    public class AgarIOScene : IScene
    {
        public void StartScene()
        {
            var mc = Player.CreatePlayer(new PlayerMouseInput(GameEngine.Game.window));
            new Camera(mc, 1280, 720);

            for (int i = 0; i < 9; i++)
                Player.CreatePlayer(new NullInput());

            for (int i = 0; i < 500; i++)
                Food.CreateFood();
        }
    }
}

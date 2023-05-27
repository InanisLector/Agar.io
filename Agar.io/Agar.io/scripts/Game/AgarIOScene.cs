using AgarIO.scripts.GameEngine;

namespace AgarIO.scripts.Game
{
    public class AgarIOScene : IScene
    {
        public void StartScene()
        {
            Player.CreatePlayer(new PlayerMouseInput(Game.window));

            for (int i = 0; i < 500; i++)
                Food.CreateFood();
        }
    }
}
